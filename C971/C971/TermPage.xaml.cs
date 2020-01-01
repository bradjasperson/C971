using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using C971.Models;

namespace C971
{
    public partial class TermPage : ContentPage
    {
        public TermPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var term = (Term)BindingContext;
            listView.ItemsSource = await App.Database.GetCoursesAsync(term.ID);
        }
        
        async void OnTermEditClicked(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            await Navigation.PushAsync(new TermEntryPage
            {
                BindingContext = term as Term
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

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            Course course = new Course();
            course.TermID = term.ID;
            await Navigation.PushAsync(new CourseEntryPage
            {
                BindingContext = course as Course
            });
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            await App.Database.DeleteTermAsync(term);
            await Navigation.PopAsync();
        }
    }
}