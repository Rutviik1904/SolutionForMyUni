using Microsoft.AspNetCore.Identity;
using MyUni.Web.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyUni.Web.Models
{
    public class MyIdentityUser
         : IdentityUser<Guid>
    {
        [Display(Name = "Display Name")]
        [Required(ErrorMessage = "{0} cannot be empty.")]
        [MinLength(2, ErrorMessage = "{0} should have at least {1} characters.")]
        [StringLength(60, ErrorMessage = "{0} cannot have more than {1} characters.")]
        public string DisplayName { get; set; }


        [Display(Name = "Date of Birth")]
        [Required]
        [PersonalData]
        [Column(TypeName = "smalldatetime")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [PersonalData]
        public MyIdentityGenders Gender { get; set; }


        [Required(ErrorMessage = "Please enter Your Phone Number")]
        [Display(Name = "MobileNumber")]
        [PersonalData]
        public string MobileNumber { get; set; }


        [Display(Name = "Select Your User Role")]
        [Required]
        public MyIdentityRoleNames UserRole { get; set; }
    }
}
