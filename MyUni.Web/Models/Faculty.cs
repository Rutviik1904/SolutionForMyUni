using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyUni.Web.Models.Enums;

namespace MyUni.Web.Models
{
    [Table("Faculties")]
    public class Faculty
    {


        [Display(Name = "User ID")]
        [ForeignKey(nameof(Faculty.User))]
        public Guid UserId { get; set; }
        public MyIdentityUser User { get; set; }

        [Display(Name = "Faculty ID")]
        [Key]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MaxLength(5, ErrorMessage = "{0} should contain {1} characters.")]
        [MinLength(3, ErrorMessage = "{0} should contain {1} characters.")]
        public string FacultyID { get; set; }

        [Display(Name = "Faculty Type")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MinLength(3, ErrorMessage = "{0} should have more than {1} characters.")]
        [StringLength(25, ErrorMessage = "{0} cannot contain more than {1} characters.")]
        public string FacultyType { get; set; }

        public ICollection<Thesis> ThesisAssigns { get; set; }
    


      


    

        

  

    }
}
