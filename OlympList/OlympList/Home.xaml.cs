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
    public partial class Home : ContentPage
    {
        public static Label GetHeadingLabel(string text)
        {
            Label sub = new Label()
            {
                Text = text,
                FontSize = 40,
                FontFamily = "RoBo",
                HorizontalOptions = LayoutOptions.Start,
                TextColor = Color.Black
            };

            return sub;
        }

        public static Label GetTextLabel(string text)
        {
            Label text_l = new Label()
            {
                Text = text,
                FontSize = 18,
                FontFamily = "RoRe",
                TextColor = Color.Black
            };

            return text_l;
        }

        public Home()
        {
            Title = "Главная";
            BackgroundColor = Color.White;


            StackLayout sl_main = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                Margin = new Thickness(15)
            };

            
            sl_main.Children.Add(GetHeadingLabel("О чём это?"));
            sl_main.Children.Add(GetTextLabel(Globals.main_article[0]));

            sl_main.Children.Add(GetHeadingLabel("Зачем это нужно?"));
            sl_main.Children.Add(GetTextLabel(Globals.main_article[1]));


            //list with arrows
            for (int i = 2; i < 6; i++)
            {
                Image arrow_img = new Image()
                {
                    Source = "arrow.png",
                    WidthRequest = 20,
                    HeightRequest = 20,
                    VerticalOptions = LayoutOptions.Start
                };

                Label list_text = new Label()
                {
                    Text = Globals.main_article[i],
                    FontSize = 18,
                    FontFamily = "RoRe",
                    HorizontalOptions = LayoutOptions.Start,
                    TextColor = Color.Black
                };

                StackLayout sl_list = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.Start,
                    Children = { arrow_img, list_text }
                };
                sl_main.Children.Add(sl_list);
            }
            

            //text describing plot
            sl_main.Children.Add(GetTextLabel(Globals.main_article[6]));

            Image plot_img = new Image()
            {
                Source = "meta_chart.png",
                WidthRequest = 250,
                HeightRequest = 250
            };
            sl_main.Children.Add(plot_img);

            
            sl_main.Children.Add(GetHeadingLabel("Как поможет приложение?"));
            sl_main.Children.Add(GetTextLabel(Globals.main_article[7]));


            ScrollView scrollview = new ScrollView
            {
                Content = sl_main
            };
            this.Content = scrollview;
        }

    }
}