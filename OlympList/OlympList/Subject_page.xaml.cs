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
    public partial class Subject_page : ContentPage
    {
        public Subject_page(string subj_name)
        {
            try
            {
                //in case if necessary info is not downloaded
                GlobalFunctions.InitialiseOlymps();

                Title = subj_name;
                BackgroundColor = Color.White;


                StackLayout sl_main = new StackLayout()
                {
                    Margin = new Thickness(3),
                    Spacing = 3,
                    Children = { }
                };


                //search among olympiads of this subject
                SearchBar search = new SearchBar()
                {
                    Placeholder = "Найти олимпиады...",
                    Text = ""
                };
                search.SearchButtonPressed += async (s, e) =>
                {
                    await Navigation.PushAsync(new SearchPage(search.Text, subj_name));
                };
                sl_main.Children.Add(search);


                //show block with olympiad info
                foreach (var olymp in Globals.Subj_olympiads[subj_name])
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

                sl_main.Children.Add(GlobalFunctions.GetOlRuLink());

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