﻿using System;
using System.IO;
using Xamarin.Forms;
using C971.Models;

namespace C971
{
    public partial class AssessmentEntryPage : ContentPage
    {
        public AssessmentEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var assessment = (Assessment)BindingContext;
            if (assessment.AssessmentType != null)
            {
                picker.SelectedItem = assessment.AssessmentType;
            }
        }
        
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var assessment = (Assessment)BindingContext;
            assessment.DueDate = dueDatePicker.Date;

            try
            {
                assessment.AssessmentType = (string)picker.ItemsSource[picker.SelectedIndex];
            }
            catch
            {
                { errorLabel.Text = "Blank fields detected!"; }
            }
            assessment.Detail = $"{assessment.AssessmentType} - {assessment.DueDate.ToShortDateString()}";
            if (String.IsNullOrWhiteSpace(assessment.Text) == false & assessment.AssessmentType != null)
            {
                await App.Database.SaveAssessmentAsync(assessment);
                await Navigation.PopAsync();
            }
            else { errorLabel.Text = "Blank fields detected!"; }
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var assessment = (Assessment)BindingContext;
            await App.Database.DeleteAssessmentAsync(assessment);
            await Navigation.PopAsync();
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
        }
    }
}