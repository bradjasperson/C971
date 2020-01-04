using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using C971.Models;

namespace C971.Data
{
    class SampleData
    {
        public async void AutoPop()
        {
            List<Term> terms = await App.Database.GetTermsAsync();
            if (terms.Count == 0)
            {
                Term term = new Term
                {
                    Text = "Sample Term",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1),
                };
                term.Detail = $"{term.StartDate.ToShortDateString()} - {term.EndDate.ToShortDateString()}";
                await App.Database.SaveTermAsync(term);
                terms = await App.Database.GetTermsAsync();
                int termID = terms[0].ID;
                Course course = new Course
                {
                    Text = "Sample Course",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(6),
                    Status = "In Progress",
                    TermID = termID,
                    InstructorName = "Brad Jasperson",
                    InstructorEmail = "bjasper@wgu.edu",
                    InstructorPhone = "(801) 555-0179",
                };
                course.Detail = $"{course.StartDate.ToShortDateString()} - {course.EndDate.ToShortDateString()}";
                course.InstructorDetail = $"{course.InstructorName} \n {course.InstructorEmail} \n {course.InstructorPhone}";
                await App.Database.SaveCourseAsync(course);
                List<Course> courses = await App.Database.GetCoursesAsync(termID);
                int courseID = courses[0].ID;
                Assessment assessmentA = new Assessment
                {
                    Text = "Sample Assessment 1",
                    DueDate = DateTime.Now.AddMonths(1),
                    CourseID = courseID,
                    AssessmentType = "Objective",
                };
                assessmentA.Detail = $"{assessmentA.AssessmentType} - {assessmentA.DueDate.ToShortDateString()}";
                Assessment assessmentB = new Assessment
                {
                    Text = "Sample Assessment 1",
                    DueDate = DateTime.Now.AddMonths(2),
                    CourseID = courseID,
                    AssessmentType = "Performance",
                };
                assessmentB.Detail = $"{assessmentB.AssessmentType} - {assessmentB.DueDate.ToShortDateString()}";
                
                await App.Database.SaveAssessmentAsync(assessmentA);
                await App.Database.SaveAssessmentAsync(assessmentB);
            }
        }
    }
}
