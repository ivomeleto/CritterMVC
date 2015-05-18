using Critter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CritterMVC.ViewModels
{
    public class UserViewModel
    {
        public IQueryable<CritViewModel> Crits { get; set; }
        public string Bio { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }

        public object FromModel(User user)
        {
            return new UserViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                AvatarUrl = user.AvatarUrl,
                Crits = user.Crits.AsQueryable().Select(CritViewModel.ViewMidel)
            };
        }
    }
}