using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment                             // Enrollment entity functions as a many-to-many join table with payload in the database. This means that the Enrollment table contains additional data besides foreign keys for the joined tables (a primary key and a Grade property).
    {                                                   //If the Enrollment table didn't include grade information, it would only need to contain the two foreign keys CourseID and StudentID. In that case, it would correspond to a many-to-many join table without payload (or a pure join table) in the database, and you wouldn't have to create a model class for it at all.
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }                   //CourseID foreign key property
        public int StudentID { get; set; }                  //StudentID foreign key property
        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }         //Navigation Property, Since 1-1 Relationship no need of Collection (An enrollment record is for a single course)
        public virtual Student Student { get; set; }       //Navigation Property, Since 1-1 Relationship no need of Collection (An enrollment record is for a single student)
    }
}