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
            BindingContext = await App.Database.GetTermAsync(term.ID);
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
                await Navigation.PushAsync(new CoursePage
                {
                    BindingContext = e.SelectedItem as Course
                });
            }
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            List<Course> courses = await App.Database.GetCoursesAsync(term.ID);
            if (courses.Count < 6)
            {
                Course course = new Course
                {
                    TermID = term.ID
                };
                await Navigation.PushAsync(new CourseEntryPage
                {
                    BindingContext = course as Course
                });
            }
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            await App.Database.DeleteTermAsync(term);
            await Navigation.PopAsync();
        }
    }
}