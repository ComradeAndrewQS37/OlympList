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
    public partial class OlympPage : ContentPage
    {
        public OlympPage(string ol_name, string ol_alink, string ol_level, string ol_profile, string ol_subject)
        {
            try
            {
                //in case if necessary info is not downloaded
                GlobalFunctions.InitialiseOlymps();

                //getting olymp info from its own web page
                List<string> buff_list = WebParsing.OlympPageScrap(ol_alink);
                string ol_about = buff_list[0];
                string ol_oflink = buff_list[1];
                string ol_logo = buff_list[2];


                Title = ol_name;
                BackgroundColor = Color.White;


                StackLayout sl_main = new StackLayout()
                {
                    Margin = new Thickness(5),
                    Spacing = 5
                };


                //Page head with title and logo

                Label name_label = new Label
                {
                    Text = ol_name,
                    FontSize = 30,
                    FontFamily = "RoBo",
                    TextColor = Color.Black,
                    FontAttributes = FontAttributes.Bold,
                    HorizontalTextAlignment = TextAlignment.Center
                };

                Image logo_img = new Image()
                {
                    WidthRequest = 100,
                    HeightRequest=100,
                    Aspect= Aspect.AspectFit
                };

                if (ol_logo == "")
                {
                    logo_img.Source = "book_colored.png";
                }
                else
                {
                    logo_img.Source = ImageSource.FromUri(new Uri(ol_logo));
                }

                Frame img_frame = new Frame
                {
                    BorderColor = Color.Blue,
                    HasShadow = false
                };
                img_frame.Content = logo_img;

                StackLayout head_sl = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    Children = { img_frame, name_label }
                };
                sl_main.Children.Add(head_sl);


                //level and link in grid 

                BoxView level_box = new BoxView
                {
                    Color = Color.FromHex("BFEAFF")
                };

                Label level_label = new Label
                {
                    Text = $"{ol_level} уровень",
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontAttributes = FontAttributes.Italic,
                    FontSize = 15,
                    TextColor = Color.FromHex("214759")
                };

                Button link_button = new Button
                {
                    Text = "Сайт олимпиады",
                    HorizontalOptions = LayoutOptions.End,
                    VerticalOptions = LayoutOptions.End,
                    TextColor = Color.FromHex("3F4B52"),
                    FontSize = 20,
                    BackgroundColor = Color.White
                };

                link_button.Clicked += async (s, e) =>
                {
                    await Xamarin.Essentials.Launcher.OpenAsync(new Uri(ol_oflink));
                };

                //saving to grid
                Grid grid = new Grid
                {
                    RowSpacing = 4,
                    ColumnSpacing = 4,
                    Margin = new Thickness(5),
                    RowDefinitions = { new RowDefinition { Height = GridLength.Auto } },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width = new GridLength(120) },
                        new ColumnDefinition { Width = GridLength.Auto }
                    }
                };
                grid.Children.Add(level_box, 0, 0);
                grid.Children.Add(level_label, 0, 0);
                grid.Children.Add(link_button, 1, 0);
                sl_main.Children.Add(grid);

                //preparation link
                Button prep_button = new Button
                {
                    Text = "Материалы прошлых лет",
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 20,
                    BackgroundColor = Color.White
                };
                prep_button.Clicked += async (s, e) =>
                {
                    await Xamarin.Essentials.Launcher.OpenAsync(new Uri(ol_alink + "/tasks"));
                };

                //subject labels
                Label subject_label1 = new Label
                {
                    Text = "Предмет:",
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 25,
                    FontFamily = "RoBo"
                };

                Label subject_label2 = new Label
                {
                    Text = ol_subject,
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = 20,
                    HorizontalTextAlignment = TextAlignment.Center
                };

                sl_main.Children.Add(prep_button);
                sl_main.Children.Add(subject_label1);
                sl_main.Children.Add(subject_label2);

                //profile labels
                if (ol_profile != "")
                {
                    Label profile_label1 = new Label
                    {
                        Text = "Профиль:",
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        FontSize = 25,
                        FontFamily = "RoBo"
                    };

                    Label profile_label2 = new Label
                    {
                        Text = ol_profile,
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        FontSize = 20,
                        HorizontalTextAlignment = TextAlignment.Center
                    };
                    
                    sl_main.Children.Add(profile_label1);
                    sl_main.Children.Add(profile_label2);
                }


                //about blocks

                foreach (string parag1 in System.Text.RegularExpressions.Regex.Split(ol_about, "\n"))
                {
                    string parag = parag1.Replace("\t", "").Replace("&raquo;", "").Replace("&laquo;", "").Replace("&ndash;", "").Replace("&nbsp;", "").Replace("\n", "");
                    if (parag == "" || parag.Contains("arrow") || parag.Contains("вернуть описание"))
                    {
                        continue;
                    }
                    
                    BoxView text_box = new BoxView()
                    {
                        Margin = new Thickness(0, 0, 15, 0),
                        WidthRequest = 4,
                        Color = Color.FromHex("4D6D77")

                    };
                    Label text_label = new Label()
                    {
                        Text = parag,
                        TextColor = Color.Black,
                        FontSize = 18,
                        FontFamily = "RoRe"
                    };

                    StackLayout text_sl = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        Children = { text_box, text_label }
                    };

                    sl_main.Children.Add(text_sl);
                }

                //to make space after
                sl_main.Children.Add(new Label() { HeightRequest = 20 });

                //event date
                List<DateTime> date_events = new List<DateTime>();
                foreach (DateTime key in Globals.DateOlympList.Keys)
                {
                    foreach (Olympiad olympd in Globals.DateOlympList[key])
                    {
                        if (olympd.name == ol_name && !date_events.Contains(key))
                        {
                            date_events.Add(key);
                        }
                    }
                }

                foreach (DateTime date_event in date_events)
                {
                    Frame fr_date = new Frame
                    {
                        BorderColor = Color.Blue,
                        HasShadow = false,
                        VerticalOptions = LayoutOptions.Center
                    };

                    Label l_date = new Label()
                    {
                        Text = Convert.ToString(date_event.Day) + " " + Convert.ToString(Globals.month_names_rod[date_event.Month - 1]),
                        TextColor = Color.Black,
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        FontFamily = "RoBo"
                    };

                    var day_tap = new TapGestureRecognizer();
                    day_tap.Tapped += async (s, e) =>
                    {
                        await Navigation.PushAsync(new DayPage(date_event));
                    };
                    fr_date.GestureRecognizers.Add(day_tap);

                    fr_date.Content = l_date;

                    sl_main.Children.Add(fr_date);
                }
                if (date_events.Count > 0)
                {
                    //to make space after
                    sl_main.Children.Add(new Label() { HeightRequest = 20 });
                }

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