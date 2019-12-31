using System;
using System.IO;
using Xamarin.Forms;
using C971.Models;

namespace C971
{
    public partial class TermEntryPage : ContentPage
    {
        public TermEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            term.StartDate = startDatePicker.Date;
            term.EndDate = endDatePicker.Date;
            term.Detail = $"{term.StartDate.ToShortDateString()} - {term.EndDate.ToShortDateString()}";
            if (String.IsNullOrWhiteSpace(term.Text) == false)
            {
                await App.Database.SaveTermAsync(term);
                await Navigation.PopAsync();
            }
            else { errorLabel.Text = "Term Title is a required field!"; }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var term = (Term)BindingContext;
            await App.Database.DeleteTermAsync(term);
            await Navigation.PopAsync();
        }
        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
        }
    }
}