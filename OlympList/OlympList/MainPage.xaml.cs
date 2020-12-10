using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OlympList
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            Detail = new NavigationPage(new Home())
            {
                BarBackgroundColor = Color.FromHex("#3CC0EA"),
                BarTextColor = Color.White
            };
            IsPresented = false;
        }
        
        //activities for buttons described in MainPage.xaml
        private void ButtonOlymp(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Olympiads())
            {
                BarBackgroundColor = Color.FromHex("#3CC0EA"),
                BarTextColor = Color.White
            };
            IsPresented = false;

        }

        private void ButtonCal(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Calend())
            {
                BarBackgroundColor = Color.FromHex("#3CC0EA"),
                BarTextColor = Color.White
            };
            IsPresented = false;

        }

        private void ButtonPrep(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Prep())
            {
                BarBackgroundColor = Color.FromHex("#3CC0EA"),
                BarTextColor = Color.White
            };
            IsPresented = false;

        }

        private void ButtonHome(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Home())
            {
                BarBackgroundColor = Color.FromHex("#3CC0EA"),
                BarTextColor = Color.White
            };
            IsPresented = false;

        }

        private void ButtonRecom(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Recom())
            {
                BarBackgroundColor = Color.FromHex("#3CC0EA"),
                BarTextColor = Color.White
            };
            IsPresented = false;

        }

        private void ButtonUnis(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new UnisPage())
            {
                BarBackgroundColor = Color.FromHex("#3CC0EA"),
                BarTextColor = Color.White
            };
            IsPresented = false;

        }

    }
}
