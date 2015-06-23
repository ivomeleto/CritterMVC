using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Models
{
    public class Vote
    {

        [Key]
        public int Id { get; set; }

        public virtual User User { get; set; }
    }
}
