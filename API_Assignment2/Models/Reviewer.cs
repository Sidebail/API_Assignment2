using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Assignment2.Models
{
    [Table("reviewers")]
    public class Reviewer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reviewer()
        {
            reviews = new HashSet<Review>();
        }

        [Key]
        public int reviewer_id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string reviewer_name { get; set; }

        [StringLength(50)]
        [Display(Name = "EMail")]
        public string reviewer_email { get; set; }

        [StringLength(50)]
        [Display(Name = "Media")]
        public string reviewer_workplace { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> reviews { get; set; }
    }
}
