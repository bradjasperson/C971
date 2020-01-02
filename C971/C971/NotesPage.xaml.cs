using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Essentials;
using C971.Models;
using System.Threading.Tasks;

namespace C971
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }

       
        async void BtnShare_Clicked(object sender, System.EventArgs e)
        {
            var course = (Course)BindingContext;
            if (String.IsNullOrWhiteSpace(course.Notes) == false)
            {
                errorLabel.Text = null;
                await ShareText(course.Notes);
            }
            else { errorLabel.Text = "Please enter a note."; }
        }

        public async Task ShareText(string note)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = note,
                Title = "Share Note"
            });
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            if (String.IsNullOrWhiteSpace(course.Notes) == false)
            {
                await App.Database.SaveCourseAsync(course);
                await Navigation.PopAsync();
            }
            else { errorLabel.Text = "Please enter a note."; }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var course = (Course)BindingContext;
            course.Notes = null;
            await App.Database.SaveCourseAsync(course);
            await Navigation.PopAsync();
        }

    }
}