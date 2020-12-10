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
    public partial class SearchPage : ContentPage
    {
        private List<Olympiad> RefreshResults(List<Olympiad> to_search, string keyword)
        {
            List<Olympiad> Found_items = new List<Olympiad>();
            foreach (Olympiad el in to_search)
            {
                if (el.name.ToLower().Contains(keyword.ToLower()))
                {
                    Found_items.Add(el);
                }
            }

            return Found_items;
        }
        public SearchPage(string s_text, string subject="")
        {
            Title = "Поиск";
            BackgroundColor = Color.White;

            //where to search
            List<Olympiad> to_search;

            if (subject != "")
            {
                to_search = Globals.Subj_olympiads[subject];
            }
            else
            {
                to_search = Globals.all_olympiads;
            }

            //represents found olympiads
            ListView listview = new ListView()
            {
                SelectionMode=ListViewSelectionMode.None,
                ItemTemplate=new DataTemplate(()=>
                {
                    TextCell textcell = new TextCell { TextColor = Color.Black };
                    textcell.SetBinding(TextCell.TextProperty, "name");
                    return textcell;
                })
            };
            listview.ItemTapped += async (s, e) =>
            {
                Olympiad b_ol = (Olympiad)e.Item;
                await Navigation.PushAsync(new OlympPage(b_ol.name, b_ol.alink, b_ol.level, b_ol.profile, b_ol.subject  ));
            };

            //to search
            SearchBar search = new SearchBar()
            {
                Placeholder = "Найти олимпиады...",
                Text = s_text
            };
            search.TextChanged += (s, e) =>
            {
                listview.ItemsSource = RefreshResults(to_search, search.Text);
            };
            search.SearchButtonPressed += (s, e) =>
            {
                listview.ItemsSource = RefreshResults(to_search, search.Text);
            };
            
            //1st search during initialisation
            listview.ItemsSource = RefreshResults(to_search, search.Text);


            StackLayout sl_main = new StackLayout()
            {
                Children = { search, listview }
            };
            this.Content = sl_main;
        }
    }
}