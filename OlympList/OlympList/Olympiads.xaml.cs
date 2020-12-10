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
    public partial class Olympiads : ContentPage
    {
        public Olympiads()
        {
            try
            {
                //in case if necessary info is not downloaded
                GlobalFunctions.InitialiseOlymps();


                Title = "Олимпиады";
                BackgroundColor = Color.White;

                
                StackLayout sl_main = new StackLayout()
                {
                    Margin = new Thickness(3),
                    Spacing = 3,
                    Children = { }
                };

                //search among all olympiads
                SearchBar search = new SearchBar()
                {
                    Placeholder = "Найти олимпиады...",
                    Text = ""
                };
                search.SearchButtonPressed += async (s, e) =>
                {
                    await Navigation.PushAsync(new SearchPage(search.Text));
                };
                sl_main.Children.Add(search);

                foreach (string subj_name in Globals.Subjects_List)
                {
                    Frame fr = new Frame
                    {
                        BorderColor = Color.Blue,
                        HasShadow = false
                    };

                    Label fr_cont = new Label()
                    {
                        Text = subj_name,
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Start,
                        FontFamily = "RoBo",
                        TextColor = Color.Black
                    };

                    StackLayout fr_cont_sl = new StackLayout() { Children = { fr_cont } };
                    fr.Content = fr_cont_sl;

                    var subj_tap = new TapGestureRecognizer();
                    subj_tap.Tapped += async (s, e) =>
                    {
                        await Navigation.PushAsync(new Subject_page(subj_name));
                    };

                    fr.GestureRecognizers.Add(subj_tap);

                    sl_main.Children.Add(fr);
                }

                //stacklayout with olimpiada.ru link
                sl_main.Children.Add(GlobalFunctions.GetOlRuLink());

                ScrollView scrollview = new ScrollView
                {
                    Content = sl_main
                };
                this.Content = scrollview;
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