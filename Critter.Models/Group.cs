using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Models
{
    public class Group
    {
        public Group()
        {
            this.Users = new HashSet<User>();
        }

        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
