using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using C971.Models;

namespace C971
{
    public partial class TermsPage : ContentPage
    {
        public TermsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetTermsAsync();
        }

        async void OnTermAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TermEntryPage
            {
                BindingContext = new Term()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new TermEntryPage
                {
                    BindingContext = e.SelectedItem as Term
                });
            }
        }
    }
}