using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace OlympList
{
    class GlobalFunctions
    {
        //func for calendar events initialisation
        public static List<Olympiad> GetOlympByName(List<List<string>> names)
        {
            List<Olympiad> result = new List<Olympiad>();

            foreach (List<Olympiad> list_olymp in Globals.Subj_olympiads.Values)
            {
                foreach (Olympiad olymp in list_olymp)
                {
                    foreach (List<string> pair in names)
                    {
                        if (olymp.name == pair[0] && (olymp.subject == pair[1] || pair[1] == ""))
                        {
                            result.Add(olymp);
                        }
                    }
                }
            }
            return result;
        }


        //frame for olympiad lists initialisator
        public static Frame GetOlympFrame(Olympiad olymp)
        {
            Frame fr = new Frame
            {
                BorderColor = Color.Blue,
                HasShadow = false
            };

            Label fr_title = new Label()
            {
                Text = olymp.name,
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Start,
                FontFamily = "RoBo"
            };

            Label fr_about = new Label()
            {
                Text = olymp.level + " уровень, " + olymp.subject.Substring(0, Math.Min(60, olymp.subject.Length)),
                FontSize = 15,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontFamily = "RoLi"
            };
            if (60 < olymp.subject.Length)
            {
                fr_about.Text = fr_about.Text += "...";
            }

            StackLayout fr_sl = new StackLayout()
            {
                Children = { fr_title, fr_about }
            };

            fr.Content = fr_sl;

            return fr;
        }


        //olimpiada.ru links initialiser
        public static StackLayout GetOlRuLink()
        {
            Label ol_l1 = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "Использована информация с сайта",
                FontFamily = "RoRe",
                FontAttributes = FontAttributes.Italic,
                FontSize = 13,
                TextColor = Color.Black,
            };

            Label ol_l2 = new Label()
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = "https://olimpiada.ru\n",
                FontFamily = "RoBo",
                TextColor = Color.DarkGray,
                FontSize = 13
            };
            var olru_tap = new TapGestureRecognizer();
            olru_tap.Tapped += async (s, e) =>
            {
                await Xamarin.Essentials.Launcher.OpenAsync(new Uri("https://olimpiada.ru/"));
            };

            ol_l2.GestureRecognizers.Add(olru_tap);

            StackLayout olru_sl = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = { ol_l1, ol_l2 }
            };

            return olru_sl;
        }


        //in case if necessary info is not downloaded
        public static void InitialiseOlymps()
        {
            if (Globals.Subj_olympiads.Count == 0)
            {
                WebParsing.CatalogueScrap();
            }
            if (Globals.DateOlympList.Count == 0)
            {
                Globals.DateOlympListInit();
            }
        }

    }
}
