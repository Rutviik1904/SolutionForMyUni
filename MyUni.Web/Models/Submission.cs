using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using MyUni.Web.Models.Enums;

namespace MyUni.Web.Models
{
    [Table("Submission")]
    public class Submission
    {
        [Display(Name = "Submission Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubmissionId { get; set; }

        #region Navigation Properties

        [Display(Name = "Thesis Id")]
        [Required]
        [ForeignKey(nameof(Submission.ThesisAssign))]
        public int ThesisId { get; set; }

        public Thesis ThesisAssign { get; set; }
        #endregion

        [StringLength(150)]
        public string ThesisFileUrl { get; set; }

        [StringLength(60)]
        public string FileContentType { get; set; }

        [Display(Name = "Submission Description")]
        [Required]
        [StringLength(150)]
        [Column(TypeName = "varchar")]
        public string SubmissionDesc { get; set; }

        [Display(Name = "Submission Due On")]
        [Required]
        [Column(TypeName = "smalldatetime")]
        public System.DateTime SubmissionDue { get; set; }

        [Display(Name = "Submission On")]
        [Required]
        [Column(TypeName = "smalldatetime")]
        public System.DateTime SubmissionOn { get; set; }


    }
}
