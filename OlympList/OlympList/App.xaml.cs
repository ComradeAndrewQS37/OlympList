using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OlympList
{

    public partial class App : Application
    {
        public App()
        {
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            InitializeComponent();

            MainPage = new NavigationPage(new OlympList.MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


    }
}
