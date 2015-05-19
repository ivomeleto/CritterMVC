using Critter.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace CritterMVC.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public IEnumerable<CritViewModel> PostedCrits { get; set; }
        public IEnumerable<CritViewModel> ReceivedCrits { get; set; }
        public string Bio { get; set; }
        public string FullName { get; set; }
        [DisplayName("User name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
      
    }
}