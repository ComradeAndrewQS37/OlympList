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
    public partial class Prep : ContentPage
    {
        //func for making beatified frames with links
        public Frame PrepLinker(string w_title, string w_descr, string w_link)
        {
            Frame fr = new Frame
            {
                BorderColor = Color.Blue,
                HasShadow = false,
                CornerRadius = 5,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            Label fr_title = new Label()
            {
                Text = w_title,
                TextColor = Color.Black,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontFamily = "RoBo"
            };

            Label fr_about = new Label()
            {
                Text = w_descr,
                TextColor = Color.Black,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                FontFamily = "RoLi"
            };

            StackLayout fr_sl = new StackLayout()
            {
                Children = { fr_title, fr_about }
            };

            fr.Content = fr_sl;

            var olymp_tap = new TapGestureRecognizer();
            olymp_tap.Tapped += async (s, e) =>
            {
                await Xamarin.Essentials.Launcher.OpenAsync(new Uri(w_link));
            };

            fr_sl.GestureRecognizers.Add(olymp_tap);

            return fr;
        }

        public Prep()
        {
            Title = "Подготовка";
            BackgroundColor = Color.FromHex("#FFFFFF");

            /*sl_main:
             subtitle
             text_box,text_label
             PrepLinker frames
             */

            StackLayout sl_main = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Spacing = 10,
                Margin = new Thickness(10)
            };

            Label subheading = new Label()
            {
                Text = "Как готовиться к олимпиадам?",
                TextColor = Color.Black,
                FontSize = 40,
                FontFamily = "RoBo",
                HorizontalOptions = LayoutOptions.Center
            };
            sl_main.Children.Add(subheading);


            //short article

            foreach (var art_parag in Globals.prep_article)
            {
                BoxView text_box = new BoxView()
                {
                    Margin = new Thickness(0, 0, 15, 0),
                    WidthRequest = 4,
                    Color = Color.FromHex("4D6D77")

                };
                Label text_label = new Label()
                {
                    Text = art_parag,
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

            //links
            sl_main.Children.Add(PrepLinker("Mathus", Globals.mathus_info, Globals.mathus_link));
            sl_main.Children.Add(PrepLinker("Olimpiada ru", Globals.olimpru_info, Globals.olimpru_link));
            sl_main.Children.Add(PrepLinker("Поступашки", Globals.post_info, Globals.post_link));

            //to make space after all links
            sl_main.Children.Add(new Label() { HeightRequest = 30 });

            this.Content = new ScrollView() { Content = sl_main };
        }
    }
}