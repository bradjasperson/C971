using System;
using System.IO;
using Xamarin.Forms;
using C971.Models;

namespace C971
{
    public partial class CourseEntryPage : ContentPage
    {
        public CourseEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var course = (Course)BindingContext;
            if (course.Status != null)
            {
                picker.SelectedItem = course.Status;
            }
        }
        
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            course.StartDate = startDatePicker.Date;
            course.EndDate = endDatePicker.Date;
            course.Detail = $"{course.StartDate.ToShortDateString()} - {course.EndDate.ToShortDateString()}";
            course.InstructorDetail = $"{course.InstructorName} \n {course.InstructorEmail} \n {course.InstructorPhone}";
            try
            {
                course.Status = (string)picker.ItemsSource[picker.SelectedIndex];
            }
            catch
            {
                { errorLabel.Text = "Blank fields detected!"; }
            }
            if (String.IsNullOrWhiteSpace(course.Text) == false & String.IsNullOrWhiteSpace(course.InstructorName) == false & String.IsNullOrWhiteSpace(course.InstructorEmail) == false & String.IsNullOrWhiteSpace(course.InstructorPhone) == false & course.Status != null)
            {
                await App.Database.SaveCourseAsync(course);
                await Navigation.PopAsync();
            }
            else { errorLabel.Text = "Blank fields detected!"; }
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
        }
    }
}