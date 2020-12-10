using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace OlympList
{
    class WebParsing
    {
        //func to parse single olympiad page
        public static List<string> OlympPageScrap(string alink)
        {
            //getting html script
            string url = alink;
            var web = new HtmlWeb();
            var doc = web.Load(url);


            string pg_text = "";
            string of_link = "";
            string logo_link = "";


            //getting olympiad description

            //1st paragraph
            try
            {
                var nodes1 = doc.DocumentNode.SelectNodes($"//*[@class='info block_with_margin_bottom']");
                foreach (var node in nodes1)
                {
                    foreach (var buff_tag1 in node.ChildNodes)
                    {
                        if (buff_tag1.Name == "p")
                        {
                            foreach (var buff_tag2 in buff_tag1.ChildNodes)
                            {
                                if (buff_tag2.Name == "#text")
                                {
                                    pg_text = buff_tag2.InnerText + "\n" + pg_text.Substring(0, pg_text.Length);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (NullReferenceException) { }

            //other papragraphs
            try
            {
                var nodes2 = doc.DocumentNode.SelectNodes($"//*[@id='history']");
                foreach (var node2 in nodes2)
                {
                    foreach (var ch_node2 in node2.ChildNodes)
                    {
                        if (ch_node2.Name == "p")
                        {
                            pg_text += ch_node2.InnerText + "\n";
                        }
                    }
                }
            }
            catch (NullReferenceException) { }

            //getting link to official olympiad web-site
            try
            {
                var contacts = doc.DocumentNode.SelectNodes("//div[@class='contacts']//a[@class='color']");
                foreach (var contact in contacts)
                {
                    string inner_href = contact.GetAttributeValue("href", string.Empty);
                    string inner_txt = contact.InnerText.Replace("Created with Sketch.", "").Replace("\n", "").Replace("\t", "").Replace(" ", "").Replace("...", "");
                    if (inner_href.Contains(inner_txt) && !(inner_href.Contains("@")))
                    {
                        of_link = inner_href;
                    }
                }
            }
            catch (NullReferenceException) { }


            //getting olympiad logo url
            try
            {
                var imgs = doc.DocumentNode.SelectNodes("//div[@id='white_container']//img");
                foreach (var img in imgs)
                {
                    string img_src = img.GetAttributeValue("src", string.Empty);
                    if (img_src.Contains("/files/m_activity/"))
                    {
                        logo_link = "https://olimpiada.ru/" + img_src;
                    }

                }
            }
            catch (NullReferenceException) { }

            return new List<string>() { pg_text, of_link, logo_link };
        }

        //returns available grades for olympiad
        public static List<int> GetClass(string alink)
        {
            var web = new HtmlWeb();
            var doc = web.Load(alink);

            var class_nodes = doc.DocumentNode.SelectNodes($"//*[@class='classes_types_a']");

            string classes = "";
            foreach (var class_node in class_nodes)
            {
                classes = class_node.InnerText.Replace("&ndash;", " ").Replace(" классы", "");

                List<int> classes_l = new List<int>();
                var buff_l = Regex.Split(classes, " ");
                if (classes == "")
                {
                    return new List<int>();
                }
                if (class_node.InnerText.Contains("классы"))
                {

                    for (int i = Convert.ToInt32(buff_l[0]); i <= Convert.ToInt32(buff_l[1]); i++)
                    {
                        classes_l.Add(i);
                    }
                }
                else
                {
                    classes_l.Add(Convert.ToInt32(buff_l[0]));
                }

                return classes_l;


            }

            return new List<int>();
        }


        //func to get list of all olympiads
        public static void CatalogueScrap()
        {
            //getting html script
            const string url = "https://olimpiada.ru/article/942";
            var web = new HtmlWeb();
            var doc = web.Load(url);

            var nodes = doc.DocumentNode.SelectNodes($"//*[@class='note_table']") ?? Enumerable.Empty<HtmlNode>();


            List<string> alinks = new List<string>();//links to olymp pages on olimpiada ru
            List<string> subj_names = new List<string>();//list of subjects
            List<List<Olympiad>> buff_olymps = new List<List<Olympiad>>();//olymps sorted by subjects

            bool first_node = true;//to get list of subjects
            int bo_index = 0;//index for buff_olymps


            //getting links to olympiad pages

            foreach (var node in nodes)
            {
                if (alinks.Count == 0)
                {
                    var links = node.SelectNodes("//a[@href]");
                    foreach (var link in links)
                    {
                        string hrefValue = link.GetAttributeValue("href", string.Empty);
                        if (hrefValue.Contains("/activity/"))
                        {
                            alinks.Add("http://olimpiada.ru" + hrefValue);
                            //link for tasks is just "{alink}/tasks"
                        }
                    }
                }


                //splitting whole page text
                var splittedWords = Regex.Split(node.InnerText, "\n");
                var words = splittedWords
                    .Where(x => !x.Contains("&nbsp;") && !string.IsNullOrEmpty(x.Trim()))
                    .ToList();


                bool is_imp_inf = false; //shows if we need to save info                    
                bool is_other_category = false; // shows if olymp has 'profile' attribute
                int category_cnt = 0;//type of information(level, name etc)

                //saving list of subjects
                if (first_node)
                {
                    //getting olympiad subjects
                    //subjects are parsed in wrong order and then corrected
                    List<List<string>> buff_subj = new List<List<string>>() { new List<string>(), new List<string>(), new List<string>() };
                    for (int cnt = 0; cnt < words.Count; cnt++)
                    {
                        var result = words[cnt].Substring(0, words[cnt].Count() - 5).Trim();
                        buff_subj[cnt % 3].Add(result);

                    }
                    foreach (var cnt1 in buff_subj)
                    {
                        foreach (var cnt2 in cnt1)
                        {
                            subj_names.Add(cnt2);
                        }
                    }
                    first_node = false;
                }
                //saving info on every olympiad
                else
                {
                    buff_olymps.Add(new List<Olympiad>());
                    Olympiad buff_ol = new Olympiad();

                    for (int cnt = 0; cnt < words.Count; cnt++)
                    {
                        var result = words[cnt].Trim();

                        if (is_imp_inf)
                        {
                            switch (category_cnt % 5)
                            {
                                case 0:
                                    buff_ol.name = result;
                                    break;

                                case 1:
                                    buff_ol.number = result;
                                    break;

                                case 2:
                                    buff_ol.subject = result;
                                    break;

                                case 3:
                                    if (is_other_category)
                                    {
                                        buff_ol.profile = result;
                                        break;
                                    }
                                    else
                                    {
                                        category_cnt++;
                                        goto case 4;
                                    }

                                case 4:
                                    buff_ol.level = result;
                                    buff_olymps[bo_index].Add(buff_ol);
                                    buff_ol = new Olympiad();
                                    break;
                            }
                            category_cnt++;
                        }

                        switch (result)
                        {
                            case "Уровень":
                                is_imp_inf = true;
                                break;
                            case "Профиль":
                                is_other_category = true;
                                break;
                        }

                    }

                    bo_index++;
                }

            }


            //olymp links saving
            int i = 0;
            foreach (List<Olympiad> li_ol in buff_olymps)
            {
                foreach (Olympiad ol in li_ol)
                {
                    ol.alink = alinks[i];
                    i++;
                }
            }

            //reformatting buff_olymps and subj_names into dictionary
            i = 0;
            foreach (var subj in subj_names)
            {
                Globals.Subj_olympiads.Add(subj, new List<Olympiad>());
                foreach (var ol in buff_olymps[i])
                {
                    Globals.Subj_olympiads[subj].Add(ol);

                    Globals.all_olympiads.Add(ol);
                }
                i++;
            }

            Globals.Subjects_List = subj_names;

        }
    }
}
