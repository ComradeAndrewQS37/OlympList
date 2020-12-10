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
    public partial class Uni_page : ContentPage
    {
        public Uni_page(Unis uni)
        {
            Title = uni.name;
            BackgroundColor = Color.White;

            StackLayout sl_main = new StackLayout()
            {
                Spacing = 10,
                Margin = new Thickness(10)
            };


            //Page head with title and logo

            Label name_label = new Label
            {
                Text = uni.name,
                FontSize = 30,
                FontFamily = "RoBo",
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Center
            };

            Image logo_img = new Image()
            {
                HeightRequest = 150,
                Aspect = Aspect.AspectFit,
                HorizontalOptions = LayoutOptions.Center,
                Source = uni.logo_src
            };

            sl_main.Children.Add(name_label);
            sl_main.Children.Add(logo_img);


            Button link_button = new Button
            {
                Text = "Сайт университета",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("3F4B52"),
                FontSize = 20,
                BackgroundColor = Color.White
            };

            link_button.Clicked += async (s, e) =>
            {
                await Xamarin.Essentials.Launcher.OpenAsync(new Uri(uni.alink));
            };
            sl_main.Children.Add(link_button);

            Button l_link_button = new Button
            {
                Text = "Льготы олимпиадникам",
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.FromHex("3F4B52"),
                FontSize = 20,
                BackgroundColor = Color.White
            };

            l_link_button.Clicked += async (s, e) =>
            {
                await Xamarin.Essentials.Launcher.OpenAsync(new Uri(uni.llink));
            };
            sl_main.Children.Add(l_link_button);

            //if statistics is available
            if (!uni.no_ol_rate)
            {
                Label stat_head = new Label
                {
                    Text = "Статистика",
                    FontSize = 25,
                    FontFamily = "RoBo",
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Start,
                    HorizontalTextAlignment = TextAlignment.Start
                };
                sl_main.Children.Add(stat_head);

                Label stat_all = new Label
                {
                    Text = $"Всего {uni.abs_bvi} олимпиадников из {uni.all_adm} поступивших",
                    FontSize = 18,
                    FontFamily = "RoRe",
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Start,
                    HorizontalTextAlignment = TextAlignment.Start
                };
                sl_main.Children.Add(stat_all);


                BoxView indic_main = new BoxView()
                {
                    Color = Color.FromHex("#60D6FC"),
                    HeightRequest = 40,
                    WidthRequest = 4 * uni.per_bvi,
                    HorizontalOptions = LayoutOptions.Start
                };

                Label indic_main_l = new Label()
                {
                    Text = $"    {uni.per_bvi}%",
                    FontSize = 20,
                    FontFamily = "RoRe",
                    TextColor = Color.Black,
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalTextAlignment = TextAlignment.Start
                };

                Grid indic_grid = new Grid
                {
                    RowDefinitions = { new RowDefinition() },
                    ColumnDefinitions = { new ColumnDefinition() },
                    Children = { indic_main, indic_main_l }
                };
                sl_main.Children.Add(indic_grid);


                //stats for each olympiad
                foreach (string ol_name in uni.ol_rate.Keys)
                {
                    Label name_la1 = new Label()
                    {
                        Text = ol_name,
                        FontSize = 19,
                        FontFamily = "RoBo",
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Start,
                        HorizontalTextAlignment = TextAlignment.Start
                    };
                    Label name_la2 = new Label()
                    {
                        Text = $"Всего {Convert.ToInt32(uni.ol_rate[ol_name][0])} человек",
                        FontSize = 17,
                        FontFamily = "RoLi",
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Start,
                        HorizontalTextAlignment = TextAlignment.Start
                    };

                    Label desc1 = new Label()
                    {
                        Text = "Из олимпиадников",
                        FontSize = 13,
                        FontFamily = "RoRe",
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalTextAlignment = TextAlignment.Start
                    };
                    Label desc2 = new Label()
                    {
                        Text = "Из поступивших",
                        FontSize = 13,
                        FontFamily = "RoRe",
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Start,
                        HorizontalTextAlignment = TextAlignment.Start
                    };
                    BoxView indic_ol1 = new BoxView()
                    {
                        Color = Color.FromHex("#8AB6C5"),
                        HeightRequest = 40,
                        WidthRequest = 4 * uni.ol_rate[ol_name][2],
                        HorizontalOptions = LayoutOptions.Start

                    };
                    BoxView indic_ol2 = new BoxView()
                    {
                        Color = Color.FromHex("#A2E8FF"),
                        HeightRequest = 40,
                        WidthRequest = 4 * uni.ol_rate[ol_name][1],
                        HorizontalOptions = LayoutOptions.Start
                    };

                    Label indic_l1 = new Label()
                    {
                        Text = $"    {uni.ol_rate[ol_name][2]}%",
                        FontSize = 20,
                        FontFamily = "RoRe",
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Start
                    };

                    Label indic_l2 = new Label()
                    {
                        Text = $"    {uni.ol_rate[ol_name][1]}%",
                        FontSize = 20,
                        FontFamily = "RoRe",
                        TextColor = Color.Black,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Start
                    };

                    Grid indic_gr1 = new Grid
                    {
                        RowDefinitions = { new RowDefinition() },
                        ColumnDefinitions = { new ColumnDefinition() },
                        Children = { indic_ol1, indic_l1 }
                    };
                    Grid indic_gr2 = new Grid
                    {
                        RowDefinitions = { new RowDefinition() },
                        ColumnDefinitions = { new ColumnDefinition() },
                        Children = { indic_ol2, indic_l2 }
                    };

                    StackLayout indic_sl_main = new StackLayout()
                    {
                        Spacing = 5,
                        Children = { name_la1, name_la2, desc1, indic_gr1, desc2, indic_gr2 }
                    };

                    sl_main.Children.Add(indic_sl_main);
                }
            }
            else
            {
                Label no_stat = new Label()
                {
                    FontFamily = "RoBo",
                    FontSize = 20,
                    TextColor = Color.Black,
                    Text = "Пока нет статистики для этого университета",
                    HorizontalTextAlignment = TextAlignment.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };

                sl_main.Children.Add(no_stat);
            }

            //to make space after
            sl_main.Children.Add(new Label() { HeightRequest = 20 });

            this.Content = new ScrollView() { Content = sl_main };

        }
    }
}