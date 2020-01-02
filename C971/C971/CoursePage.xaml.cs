using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using C971.Models;

namespace C971
{
    public partial class CoursePage : ContentPage
    {
        public CoursePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var course = (Course)BindingContext;
            listView.ItemsSource = await App.Database.GetAssessmentsAsync(course.ID);
            BindingContext = await App.Database.GetCourseAsync(course.ID);
        }
        
        async void OnCourseEditClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            await Navigation.PushAsync(new CourseEntryPage
            {
                BindingContext = course as Course
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new AssessmentEntryPage
                {
                    BindingContext = e.SelectedItem as Assessment
                });
            }
        }

        async void OnAddButtonClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            Assessment assessment = new Assessment
            {
                CourseID = course.ID
            };
            await Navigation.PushAsync(new AssessmentEntryPage
            {
                BindingContext = assessment as Assessment
            });
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            await App.Database.DeleteCourseAsync(course);
            await Navigation.PopAsync();
        }
        async void OnNotesButtonClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            await Navigation.PushAsync(new NotesPage
            {
                BindingContext = course as Course
            });
        }
    }
}