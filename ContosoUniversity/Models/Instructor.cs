using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Instructor
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Last Name"), StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Column("FirstName"), Display(Name = "First Name"), StringLength(50, MinimumLength =1)]
        public string  FirstMidName { get; set; }


        [DataType(DataType.Date), Display(Name = "Hire Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public DateTime HireDate { get; set; }

        [Display(Name ="Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public virtual ICollection<Course> Courses { get; set; }        // An instructor can teach any number of Courses, so Courses is defined as a collection of Course entities.
                                                                        // defined as Virtual to Take advantage of Lazy Loading i.e. Load it only when Needed.

        public virtual OfficeAssignment OfficeAssignment { get; set; }     // Our business rules state an instructor can only have at most one office, so OfficeAssignment is defined as a single OfficeAssignment entity (which may be null if no office is assigned).
    }
}