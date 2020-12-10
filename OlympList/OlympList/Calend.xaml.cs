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
    public partial class Calend : ContentPage
    {
        public Calend()
        {
            try
            {
                //in case if necessary info is not downloaded
                GlobalFunctions.InitialiseOlymps();


                Title = "Календарь";
                BackgroundColor = Color.White;

                StackLayout sl_main = new StackLayout()
                {
                    Spacing = 0
                };


                //head with days of week names

                Grid header = new Grid()
                {
                    RowSpacing = 4,
                    ColumnSpacing = 4,
                    Margin = new Thickness(5),

                    RowDefinitions = { new RowDefinition { Height = GridLength.Auto } }
                };

                for (int i = 0; i < 7; i++)
                {
                    header.ColumnDefinitions.Add(new ColumnDefinition());
                }

                string[] week = new string[] { "ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ", "ВС" };

                for (int cnt = 0; cnt < 7; cnt++)
                {
                    Label l_day = new Label()
                    {
                        Text = week[cnt],
                        FontSize = 20,
                        FontFamily = "RoBo",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };
                    header.Children.Add(l_day, cnt, 0);
                }
                sl_main.Children.Add(header);


                //calendar part

                StackLayout sl_calend = new StackLayout()
                {
                    Spacing = 10
                };

                Image today_img = new Image()//circle which indicates today
                {
                    WidthRequest = 50,
                    HeightRequest = 50,
                    Aspect = Aspect.AspectFit,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center,
                    Source = "circle.png"

                };

                DateTime curr = DateTime.Now;
                int c_pos = 2;//1st Jan 2020 day of the week
                int year = 2020;
                for (int mnt_cnt = 0; mnt_cnt < 36; mnt_cnt++)
                {
                    if (mnt_cnt != 0 && mnt_cnt % 12 == 0)
                    {
                        year++;
                    }

                    //if month is earlier then current month-1 it is not shown
                    if ((!(curr.Month == 1 && mnt_cnt == 12 && year == curr.Year - 1)) && (year < curr.Year || (year == curr.Year && mnt_cnt < curr.Month - 2)))
                    {
                        c_pos = (c_pos + Globals.num_days[mnt_cnt]) % 7;
                        continue;
                    }

                    int num_of_days = Globals.num_days[mnt_cnt];//days in the month
                    string month_name = Globals.month_names[mnt_cnt % 12];

                    Grid month_grid = new Grid
                    {
                        RowSpacing = 4,
                        ColumnSpacing = 4,
                        Margin = new Thickness(5)
                    };

                    for (int i = 0; i < 7; i++)
                    {
                        month_grid.ColumnDefinitions.Add(new ColumnDefinition());
                    }

                    int num_of_rows = (c_pos + num_of_days + ((c_pos + num_of_days) % 7)) / 7;

                    for (int i = 0; i < num_of_rows; i++)
                    {
                        month_grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(100) });
                    }

                    int grid_col_pos = c_pos;
                    int grid_row_pos = 0;
                    for (int day_num = 1; day_num <= num_of_days; day_num++)
                    {
                        Label day_label = new Label()//day number
                        {
                            Text = Convert.ToString(day_num),
                            FontSize = 20,
                            FontFamily = "RoRe",
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            TextColor = Color.Black
                        };
                        month_grid.Children.Add(day_label, grid_col_pos, grid_row_pos);

                        BoxView white_box = new BoxView()//box for tap gesture
                        {
                            Color = Color.Transparent
                        };

                        var day_tap = new TapGestureRecognizer();
                        day_tap.Tapped += async (s, e) =>
                        {
                            await Navigation.PushAsync(new DayPage(Globals.dayDate[Globals.dayLabels.IndexOf(day_label)]));
                        };
                        white_box.GestureRecognizers.Add(day_tap);

                        //to remember connection between date and label
                        Globals.dayLabels.Add(day_label);
                        Globals.dayDate.Add(new DateTime(year, mnt_cnt % 12 + 1, day_num));

                        if (new DateTime(year, mnt_cnt % 12 + 1, day_num) == DateTime.Today)
                        {
                            month_grid.Children.Add(today_img, grid_col_pos, grid_row_pos);
                        }

                        //if day has some events
                        if (Globals.DateOlympList.ContainsKey(new DateTime(year, mnt_cnt % 12 + 1, day_num)))
                        {
                            Image act_img = new Image()
                            {
                                WidthRequest = 10,
                                HeightRequest = 10,
                                Aspect = Aspect.AspectFit,
                                HorizontalOptions = LayoutOptions.Center,
                                VerticalOptions = LayoutOptions.End,
                                Source = "grey_dot.png"
                            };

                            month_grid.Children.Add(act_img, grid_col_pos, grid_row_pos);
                        }

                        month_grid.Children.Add(white_box, grid_col_pos, grid_row_pos);

                        grid_col_pos++;
                        if (grid_col_pos > 6)
                        {
                            grid_col_pos %= 7;
                            grid_row_pos++;
                        }
                    }

                    //name of month
                    Label month_l = new Label()
                    {
                        Text = month_name,
                        FontFamily = "RoBo",
                        TextColor = Color.Black,
                        FontSize = 40,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        HeightRequest = 60
                    };

                    sl_calend.Children.Add(month_l);
                    sl_calend.Children.Add(month_grid);

                    //day of the week of 1st next month
                    c_pos = (c_pos + num_of_days) % 7;
                }

                ScrollView scrollview = new ScrollView()
                {
                    Content = sl_calend
                };

                //move to today
                Button scroll_button = new Button()
                {
                    HorizontalOptions = LayoutOptions.Center,
                    Text = "К сегодняшнему дню",
                    FontFamily = "RoRe",
                    TextColor = Color.Black,
                    FontSize = 13,
                    BackgroundColor = Color.White
                };

                scroll_button.Clicked += async (s, e) =>
                {
                    await scrollview.ScrollToAsync(today_img, ScrollToPosition.Center, true);
                };

                sl_main.Children.Add(scroll_button);
                sl_main.Children.Add(scrollview);

                this.Content = sl_main;
            }
            catch(System.Net.WebException)
            {
                Title = "Нет соединения с интернетом";
                BackgroundColor = Color.White;
                this.Content = Globals.connection_lost_l;
            }
        }

    }
}