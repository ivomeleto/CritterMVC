using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Models
{
    public class Crit
    {

        public Crit()
        {
            this.Votes = new List<Vote>();
        }

        [Key]
        public int CritId { get; set; }

        [Required]
        [Display(Name = "Crit text")]
        public string Text { get; set; }

        public string AuthorUserId { get; set; }

        public User AuthorUser { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
