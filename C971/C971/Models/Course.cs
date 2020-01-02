using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace C971.Models
{
    [Table ("Course")]
    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int TermID { get; set; }
        public string Text { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
        public string InstructorName { get; set; }
        public string InstructorPhone { get; set; }
        public string InstructorEmail { get; set; }
        public string InstructorDetail { get; set; }
        public string Notes { get; set; }
        public bool Notifications { get; set; }
    }
}
