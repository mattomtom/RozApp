using System;
using System.Collections.Generic;
using RozApp.Views;
using Syncfusion.SfAutoComplete.XForms;
using Xamarin.Forms;
using RozApp.Data;
using System.Diagnostics;

namespace RozApp
{
    public class App : Application
    {
        static Database database;

        public App()
        {
            DependencyService.Register<Services.ISpeechToText>();
            DependencyService.Register<Services.ITextService>();

            MainPage = new NavigationPage(new MenuPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
