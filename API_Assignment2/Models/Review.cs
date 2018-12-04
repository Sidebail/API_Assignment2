using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace API_Assignment2.Models
{
    [Table("reviews")]
    public class Review
    {
        [Key]
        public int review_id { get; set; }

        [Display(Name = "Reviewer Name")]
        public int reviewer_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string review_name { get; set; }

        [Display(Name = "Score")]
        public byte review_score { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Game")]
        public string review_game { get; set; }

        [StringLength(100)]
        [Display(Name = "Text")]
        public string review_text { get; set; }
    }
}
