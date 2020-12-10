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
    public partial class DayPage : ContentPage
    {
        //this page shows events on particular day
        public DayPage(DateTime date)
        {
            try
            {
                //in case if necessary info is not downloaded
                GlobalFunctions.InitialiseOlymps();


                Title = Convert.ToString(date.Day) + " " + Convert.ToString(Globals.month_names_rod[date.Month - 1]) + " " + Convert.ToString(date.Year);
                BackgroundColor = Color.White;

                if (Globals.DateOlympList.ContainsKey(date))
                {
                    StackLayout sl_main = new StackLayout
                    {
                        Spacing = 5,
                        Margin = new Thickness(5)
                    };

                    //making frame for each olymp this day
                    foreach (var olymp in Globals.DateOlympList[date])
                    {
                        Frame fr = GlobalFunctions.GetOlympFrame(olymp);

                        var olymp_tap = new TapGestureRecognizer();
                        olymp_tap.Tapped += async (s, e) =>
                        {
                            await Navigation.PushAsync(new OlympPage(olymp.name, olymp.alink, olymp.level, olymp.profile, olymp.subject));
                        };
                        fr.GestureRecognizers.Add(olymp_tap);

                        sl_main.Children.Add(fr);
                    }

                    this.Content = new ScrollView() { Content = sl_main };
                }

                else
                {
                    Label no_olymps = new Label()
                    {
                        Text = "Событий нет",
                        TextColor = Color.Black,
                        FontSize = 30,
                        FontFamily = "RoBo",
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                    };
                    this.Content = no_olymps;
                };
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