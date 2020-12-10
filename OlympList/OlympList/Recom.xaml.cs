using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OlympList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recom : ContentPage
    {
        //creates labels used on page
        public static Label GetPickerLabel(string text)
        {
            Label text_l = new Label()
            {
                Text = text,
                TextColor = Color.Black,
                FontSize = 18,
                FontFamily = "RoRe",
                HorizontalOptions = LayoutOptions.Start
            };

            return text_l;
        }

        //creates Picker objects used on page
        public static Picker GetPicker(string title, List<string> items, int sp_index)
        {
            Picker re_picker = new Picker()
            {
                Title = title
            };
            
            foreach (string item in items)
            {
                re_picker.Items.Add(item);
            }

            re_picker.SelectedIndexChanged += (s, e) =>
            {
                Globals.PersonalInfo[sp_index] = re_picker.Items[re_picker.SelectedIndex];

            };

            return re_picker;
        }

        //creates checkbox blocks used on page
        public static StackLayout CheckBoxMaker(string uni_name)
        {
            CheckBox cb = new CheckBox() { IsChecked = false, VerticalOptions = LayoutOptions.Center, Color=Color.Blue };
            cb.CheckedChanged += (sender, e) =>
            {
                if (e.Value)
                {
                    Globals.PersonalUnis.Add(uni_name);
                }
                else
                {
                    Globals.PersonalUnis.Remove(uni_name);
                }
            };

            Label cbl = new Label()
            {
                Text = uni_name,
                FontSize = 20,
                TextColor = Color.Black,
                FontFamily = "RoRe",
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            StackLayout cb_sl = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Children = { cb, cbl }
            };

            return cb_sl;
        }


        public Recom()
        {
            try
            {
                //in case if necessary info is not downloaded
                GlobalFunctions.InitialiseOlymps();

                Title = "Рекомендации";
                BackgroundColor = Color.White;

                StackLayout sl_main = new StackLayout()
                {
                    Orientation = StackOrientation.Vertical,
                    Spacing = 15,
                    Margin = new Thickness(10)
                };

                Label subh = new Label()
                {
                    Text = "Подборка",
                    TextColor = Color.Black,
                    FontSize = 40,
                    FontFamily = "RoBo",
                    HorizontalOptions = LayoutOptions.Start
                };
                sl_main.Children.Add(subh);

                //if user hasn't done all options yet
                if (Globals.PersonalInfo[0] == "")
                {
                    
                    sl_main.Children.Add(GetPickerLabel("Помогите нам сделать рекомендации персональными, заполнив несколько полей о себе"));

                    sl_main.Children.Add(GetPickerLabel("В каком классе вы обучаетесь?"));
                    sl_main.Children.Add(GetPicker("Класс обучения", new List<string>() { "5", "6", "7", "8", "9", "10", "11" },1));

                    sl_main.Children.Add(GetPickerLabel("Какая предметная область вас интересует?"));
                    sl_main.Children.Add(GetPicker("Предметная область", new List<string>() { "Естесственные науки", "Гуманитарные науки", "Точные науки", "Творчество", "Иностранные языки", "Профессиональные направления" },2));

                    sl_main.Children.Add(GetPickerLabel("В какой вуз хотели бы поступить?(пока доступна статистика не по всем вузам)"));
                    

                    List<string> available_unis = new List<string>() { "МГУ", "СПбГУ", "МФТИ", "МИФИ", "ВШЭ", "РАНХиГС", "МГИМО", "ИТМО", "МГТУ", "НГУ" };

                    foreach (string unii in available_unis)
                    {
                        sl_main.Children.Add(CheckBoxMaker(unii));
                    }

                    Button submit_button = new Button()
                    {
                        Text = "Сохранить данные",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        TextColor = Color.FromHex("3F4B52"),
                        FontSize = 20,
                        BackgroundColor = Color.White
                    };
                    submit_button.Clicked += async (s, e) =>
                    {
                        //if grade and sphere options are done
                        if (Globals.PersonalInfo[1] != "" && Globals.PersonalInfo[2] != "")
                        {
                            Globals.PersonalInfo[0] = "1";//means user made all options
                            Globals.rec_done = false;//means new recommendation is required
                            Globals.to_recom1 = new List<Olympiad>();//all recommendations
                            Globals.to_recom2 = new List<Olympiad>();//recommendations connected with selected unis

                            //refreshing the page
                            await Navigation.PopAsync(false);
                            await Navigation.PushAsync(new Recom());
                        }
                        else
                        {
                            //if not all necessary options are done
                            await DisplayAlert("Не хватает данных", "Для корректных рекомендаций введите класс и предпочтительную область", "OK");
                        }
                    };
                    sl_main.Children.Add(submit_button);

                }
                else
                {
                    //if we are ready to make recommendation(or already made it)

                    //printing saved user info
                    string unis_string = "";
                    foreach (string s in Globals.PersonalUnis)
                    {
                        unis_string += s + ", ";
                    }
                    if (unis_string == "")
                    {
                        unis_string = "не выбрано";
                    }
                    else
                    {
                        unis_string = unis_string.Substring(0, unis_string.Length - 2);
                    }
                    Label check_data = new Label()
                    {
                        Text = $"Класс обучения: {Globals.PersonalInfo[1]}\nПредпочтительная предметная область: {Globals.PersonalInfo[2]}\nВузы: {unis_string}\nВсё верно? Если нет, то можно изменить эти данные",
                        FontSize = 18,
                        TextColor = Color.Black,
                        FontFamily = "RoRe",
                        HorizontalOptions = LayoutOptions.Start
                    };
                    sl_main.Children.Add(check_data);

                    Button change_button = new Button()
                    {
                        Text = "Изменить данные",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        TextColor = Color.FromHex("3F4B52"),
                        FontSize = 20,
                        BackgroundColor = Color.White
                    };
                    change_button.Clicked += async (s, e) =>
                    {
                        //if user wants to change some personal info
                        Globals.PersonalInfo[0] = "";
                        await Navigation.PopAsync(false);
                        await Navigation.PushAsync(new Recom(), false);
                    };
                    sl_main.Children.Add(change_button);


                    //if we need to do new recommendation

                    if (!Globals.rec_done)
                    {
                        foreach (var sub in Globals.SpheresSubj[Globals.PersonalInfo[2]])
                        {
                            foreach (var olymp in Globals.Subj_olympiads[sub])
                            {
                                if (olymp.classes.Count == 0)
                                {
                                    //if we don't know available grades for this olympiad
                                    olymp.classes = WebParsing.GetClass(olymp.alink);
                                }

                                if (!olymp.classes.Contains(Convert.ToInt32(Globals.PersonalInfo[1])))
                                {
                                    //if olympiad is not held for chosen grade
                                    continue;
                                }

                                if (Globals.PersonalUnis.Count == 0)
                                {
                                    //if user hasn't chosen any unis
                                    Globals.to_recom1.Add(olymp);
                                }
                                else
                                {
                                    //if we haven't added olymp to any recom list before
                                    if (!(Globals.to_recom1.Contains(olymp) && Globals.to_recom2.Contains(olymp)))
                                    {
                                        //iterate over chosen unis
                                        foreach (var per_uni in Globals.PersonalUnis)
                                        {
                                            //if uni object has any information about olymps for this uni
                                            if (!Globals.UnisDict[per_uni].no_ol_rate)
                                            {
                                                //if current olymp is among them
                                                if (Globals.UnisDict[per_uni].ol_rate.ContainsKey(olymp.name) && !Globals.to_recom2.Contains(olymp))
                                                {
                                                    Globals.to_recom2.Add(olymp);
                                                }
                                                else if (!Globals.to_recom1.Contains(olymp))
                                                {
                                                    Globals.to_recom1.Add(olymp);
                                                }
                                            }
                                            else if (!Globals.to_recom1.Contains(olymp))
                                            {
                                                Globals.to_recom1.Add(olymp);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //recommendation is ready
                        Globals.rec_done = true;
                    }

                    //if nothing is suitable for chosen options
                    if (Globals.to_recom1.Count == 0)
                    {
                        Label no_rec = new Label()
                        {
                            Text = "Пока не знаем, что вам посоветовать(попробуйте изменить введённые данные)",
                            TextColor = Color.Black,
                            FontFamily = "RoBo",
                            FontSize = 30,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalTextAlignment = TextAlignment.Center
                        };
                        sl_main.Children.Add((no_rec));
                    }
                    else
                    {
                        Label think = new Label()
                        {
                            Text = "Думаем, вам стоит поучаствовать в этих олимпиадах:",
                            FontSize = 20,
                            TextColor = Color.Black,
                            FontFamily = "RoBo",
                            HorizontalOptions = LayoutOptions.Center
                        };
                        sl_main.Children.Add(think);
                    }

                    if (Globals.to_recom2.Count < 3)
                    {
                        Globals.to_recom2.AddRange(Globals.to_recom1);
                    }

                    foreach (var olymp in Globals.to_recom2)
                    {
                        Frame fr_olymp = GlobalFunctions.GetOlympFrame(olymp);
                        
                        var olymp_tap = new TapGestureRecognizer();
                        olymp_tap.Tapped += async (s, e) =>
                        {
                            await Navigation.PushAsync(new OlympPage(olymp.name, olymp.alink, olymp.level, olymp.profile, olymp.subject));
                        };

                        fr_olymp.GestureRecognizers.Add(olymp_tap);

                        sl_main.Children.Add(fr_olymp);
                    }
                }

                //to make space after
                sl_main.Children.Add(new Label() { HeightRequest = 20 });

                this.Content = new ScrollView() { Content = sl_main };
            }
            catch (System.Net.WebException)
            {
                Title = "Нет соединения с интернетом";
                BackgroundColor = Color.White;

                this.Content = Globals.connection_lost_l;
            }

        }
    }
}