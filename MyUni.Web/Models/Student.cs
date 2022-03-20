using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyUni.Web.Models
{
    [Table("Students")]
    public class Student
    {

        ///     Mapped to the ID column of the Identity User

        [Display(Name = "User ID")]
        [Key]
        [ForeignKey(nameof(Student.User))]
        public Guid UserId { get; set; }
        public MyIdentityUser User { get; set; }


        [Display(Name = "Enrollment Number")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [StringLength(10, ErrorMessage = "{0} should contain {1} characters.")]
        [MinLength(10, ErrorMessage = "{0} should contain {1} characters.")]
        public string EnrollmentID { get; set; }


        [Display(Name = "Parent Name")]
        [MinLength(2, ErrorMessage = "{0} should have at least {1} characters.")]
        [StringLength(60, ErrorMessage = "{0} should not contain more than {1} characters.")]
        public string ParentName { get; set; }


        public ICollection<Thesis> ThesisAssigns { get; set; }

        public ICollection<Review> SubmissionReviews { get; set; }







    }
}
