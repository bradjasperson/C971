using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace C971.Models
{
    [Table ("Assessment")]
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CourseID { get; set; }
        public string Text { get; set; }
        public string Detail { get; set; }
        public DateTime DueDate { get; set; }
        public string AssessmentType { get; set; }
        public bool Notifications { get; set; }
    }
}
