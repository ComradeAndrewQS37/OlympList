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
    public partial class UnisPage : ContentPage
    {
        //list of all universities
        public UnisPage()
        {
            Title = "Университеты";
            BackgroundColor = Color.White;

            StackLayout sl_main = new StackLayout()
            {
                Margin = new Thickness(5),
                Spacing = 5
            };

            foreach (Unis uni in Globals.UnisList)
            {
                Frame fr = new Frame
                {
                    BorderColor = Color.Blue,
                    HasShadow = false
                };

                Label fr_cont = new Label()
                {
                    Text = uni.name,
                    FontSize = 20,
                    FontFamily = "RoRe",
                    TextColor = Color.Black
                };

                fr.Content = fr_cont;

                var uni_tap = new TapGestureRecognizer();
                uni_tap.Tapped += async (s, e) =>
                {
                    await Navigation.PushAsync(new Uni_page(uni));
                };

                fr.GestureRecognizers.Add(uni_tap);

                sl_main.Children.Add(fr);
            }

            //to make space after
            sl_main.Children.Add(new Label() { HeightRequest = 20 });

            this.Content = new ScrollView() { Content = sl_main };

        }
    }
}