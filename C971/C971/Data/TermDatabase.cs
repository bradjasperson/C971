using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using C971.Models;

namespace C971.Data
{
    public class TermDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TermDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Term>().Wait();
            _database.CreateTableAsync<Course>().Wait();
            _database.CreateTableAsync<Assessment>().Wait();
        }

        //Term Functions
        public Task<List<Term>> GetTermsAsync()
        {
            return _database.Table<Term>().ToListAsync();
        }

        public Task<Term> GetTermAsync(int id)
        {
            return _database.Table<Term>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTermAsync(Term term)
        {
            if (term.ID != 0)
            {
                return _database.UpdateAsync(term);
            }
            else
            {
                return _database.InsertAsync(term);
            }
        }

        public Task<int> DeleteTermAsync(Term term)
        {
            return _database.DeleteAsync(term);
        }

        //Course Functions
        public Task<List<Course>> GetCoursesAsync(int termId)
        {
            return _database.Table<Course>()
                            .Where(i => i.TermID == termId)
                            .ToListAsync();
        }

        public Task<Course> GetCourseAsync(int id)
        {
            return _database.Table<Course>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveCourseAsync(Course course)
        {
            if (course.ID != 0)
            {
                return _database.UpdateAsync(course);
            }
            else
            {
                return _database.InsertAsync(course);
            }
        }

        public Task<int> DeleteCourseAsync(Course course)
        {
            return _database.DeleteAsync(course);
        }

        //Assessment Functions
        public Task<List<Assessment>> GetAssessmentsAsync(int courseId)
        {
            return _database.Table<Assessment>()
                            .Where(i => i.CourseID == courseId)
                            .ToListAsync();
        }

        public Task<Assessment> GetAssessmentAsync(int id)
        {
            return _database.Table<Assessment>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveAssessmentAsync(Assessment assessment)
        {
            if (assessment.ID != 0)
            {
                return _database.UpdateAsync(assessment);
            }
            else
            {
                return _database.InsertAsync(assessment);
            }
        }

        public Task<int> DeleteAssessmentAsync(Assessment assessment)
        {
            return _database.DeleteAsync(assessment);
        }
    }
}
