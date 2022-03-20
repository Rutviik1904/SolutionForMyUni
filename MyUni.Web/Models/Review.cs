using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyUni.Web.Models
{
    [Table("Reviews")]
    public class Review
    {
        [Display(Name = "Submission ID")]
        [Key]
        [Required]
        [ForeignKey(nameof(Review.SubmissionDetail))]
        public int SubmissionId { get; set; }
        public Submission SubmissionDetail { get; set; }

        [Display(Name = "Student Enrollment Number")]
        [Required]
        [ForeignKey(nameof(Review.Student))]
        public string EnrollmentID { get; set; }
        public ICollection<Student> Student { get; set; }

        [Display(Name = "Reviewed By")]
        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string ReviewedBy { get; set; }

        [Display(Name = "Reviewed On")]
        [Required]
        [Column(TypeName = "smalldatetime")]
        public System.DateTime ReviewedOn { get; set; }

        [Display(Name = "Review Remarks")]
        [Required]
        [Column(TypeName = "varchar")]
        public string ReviewRemarks { get; set; }
    }
}
