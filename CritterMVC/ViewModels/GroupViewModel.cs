using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Critter.Models;

namespace CritterMVC.ViewModels
{
    public class GroupViewModel
    {
        public static Expression<Func<Group, GroupViewModel>> ViewModel
        {
            get
            {
                return x => new GroupViewModel()
                {
                    Name = x.Name,
                    Description = x.Description,
                    Users = x.Users,
                    Id = x.GroupId
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<User> Users { get; set; }
    }
}