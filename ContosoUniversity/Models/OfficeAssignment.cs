using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        [Key]                                   //An office assignment only exists in relation to the instructor it's assigned to, and therefore its primary key is also its foreign key to the Instructor entity.                                 
        [ForeignKey("Instructor")]              //But the Entity Framework can't automatically recognize InstructorID as the primary key of this entity because its name doesn't follow the ID or classname ID naming convention. Therefore, the Key attribute is used to identify it as the key:
        public int IntsructorID { get; set; }       //When there is a one-to-zero-or-one relationship or a one-to-one relationship between two entities EF can't work out which end of the relationship is the principal and which end is dependent. One-to-one relationships have a reference navigation property in each class to the other class.
                                                    //The ForeignKey Attribute can be applied to the dependent class to establish the relationship. 
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}