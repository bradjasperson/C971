using System;
using System.IO;
using Plugin.LocalNotifications;
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
                if (course.Notifications)
                {
                    CrossLocalNotifications.Current.Show($"{course.Text} is starting Today!", $"The course {course.Text} is beginning today. Good luck!", 100, course.StartDate.AddSeconds(5));
                    CrossLocalNotifications.Current.Show($"{course.Text} is ending Today.", $"The course {course.Text} is ending today. We hope you enjoyed it!", 101, course.EndDate.AddSeconds(5));
                }
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