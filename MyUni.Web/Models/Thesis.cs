using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyUni.Web.Models
{
    [Table("Thesis")]
    public class Thesis
    {
        [Display(Name = "Thesis Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThesisId { get; set; }

        #region #region Navigation Properties to SubmissionDetail

        public ICollection<Submission> SubmissionDetails { get; set; }

        #endregion

        [Display(Name = "Thesis Title")]
        [Required]
        [StringLength(50)]
        [Column(TypeName = "varchar")]
        public string ThesisTitle { get; set; }

        [Display(Name = "Thesis Description")]
        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string ThesisDesc { get; set; }

        #region Navigation Properties to Subject

        [Display(Name = "Subject Name")]
        [Required]
        [ForeignKey(nameof(Thesis.Subject))]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        #endregion

        #region Navigation Properties to Student

        [Display(Name = "Student Enrollment Number")]
        [Required]
        [ForeignKey(nameof(Thesis.Student))]
        public string EnrollmentID { get; set; }
        public ICollection<Student> Student { get; set; }

        #endregion

        #region Navigation Properties to Faculty

        [Display(Name = "Faculty Id")]
        [Required]
        [ForeignKey(nameof(Thesis.Faculty))]
        public string FacultyID { get; set; }
        public ICollection<Faculty> Faculty { get; set; }

        #endregion

        /* #region Navigation Properties
         [Display(Name = "Mentor Id")]
         [Required]
         [ForeignKey(nameof(ThesisAssign.Faculty))]
         public int MentorID { get; set; }
         [Display(Name = " ID")]
         public Faculty Faculty { get; set; }
         #endregion */

        [Display(Name = "Assign Date")]
        [Required]
        [Column(TypeName = "smalldatetime")]
        public System.DateTime AssignDate { get; set; }





    }
}
