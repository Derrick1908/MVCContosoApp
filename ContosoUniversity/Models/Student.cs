using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Student
    {
        public int ID { get; set; }

        [StringLength(50)]                                          //Limits Length to 50 Characters.
        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]             //Checks to see that the first character is upper case and the remaining characters are alphabetical
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 Characters.")]
        [Column("First Name")]                                     // The Column attribute specifies that when the database is created, the column of the Student table that maps to the FirstMidName property will be named FirstName. 
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]                   //The DataType attribute is used to specify a data type that is more specific than the database intrinsic type (date, not the date and time)
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]       //  The DisplayFormat attribute is used to explicitly specify the date format as DataType.Date does not specify the format of the date that is displayed. By default, the data field is displayed according to the default formats based on the server's CultureInfo.
                                                                                              //  The ApplyFormatInEditMode setting specifies that the specified formatting should also be applied when the value is displayed in a text box for editing. 
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }        //Navigation property that links this Entity to the Enrollment Entity (1-M Relatnship), defined as virtual to help in lazy loading.
    }
}