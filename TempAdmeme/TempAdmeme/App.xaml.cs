using System;
using TempAdmeme.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TempAdmeme
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            VarContainer.main = new MainPage();

            MainPage = VarContainer.main;
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
