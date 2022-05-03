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

        [Required]                                                  //Makes the name properties required fields. It is not needed for value types such as DateTime, int, double, and float. Value types cannot be assigned a null value, so they are inherently treated as required fields.
        [StringLength(50)]                                          //Limits Length to 50 Characters.
        [Display(Name = "Last Name")]                               //The Display attribute specifies that the caption for the text boxes instead of the property name in each instance (which has no space dividing the words).
        public string LastName { get; set; }

        [Required]                                                   
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]             //Checks to see that the first character is upper case and the remaining characters are alphabetical
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 Characters.")]
        [Column("First Name")]                                     // The Column attribute specifies that when the database is created, the column of the Student table that maps to the FirstMidName property will be named FirstName. 
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]                   //The DataType attribute is used to specify a data type that is more specific than the database intrinsic type (date, not the date and time)
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]       //  The DisplayFormat attribute is used to explicitly specify the date format as DataType.Date does not specify the format of the date that is displayed. By default, the data field is displayed according to the default formats based on the server's CultureInfo. The ApplyFormatInEditMode setting specifies that the specified formatting should also be applied when the value is displayed in a text box for editing. 
        [Display(Name = "Enrollment Date" )]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]               //Display attribute specifies the caption for the text boxes instead of the property name in each instance(which has no space dividing the words)
        public string FullName                     //FullName is a calculated property that returns a value that's created by concatenating two other properties. Therefore it has only a get accessor, and no FullName column will be generated in the database.
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        public virtual ICollection<Enrollment> Enrollments { get; set; }        //Navigation property that links this Entity to the Enrollment Entity (1-M Relatnship), defined as virtual to help in lazy loading.
    }
}