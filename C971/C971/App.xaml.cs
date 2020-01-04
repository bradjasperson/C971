using System;
using System.IO;
using System.Collections.Generic;
using Xamarin.Forms;
using C971.Data;
using C971.Models;
using System.Threading.Tasks;

namespace C971
{
    public partial class App : Application
    {
        static TermDatabase database;

        public static TermDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new TermDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Terms.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            SampleData autoPop = new SampleData();
            autoPop.AutoPop();
            MainPage = new NavigationPage(new TermsPage());
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