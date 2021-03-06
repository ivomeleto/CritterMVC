﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Models
{
    public class Group
    {
        private ICollection<User> _users;

        public Group()
        {
            this._users = new HashSet<User>();
        }

        [Key]
        public int GroupId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string AuthorUserId { get; set; }

        public User AuthorUser { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
