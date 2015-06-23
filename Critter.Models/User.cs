using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Critter.Models
{
    public class User : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        private ICollection<Crit> _postedCrits;

        public User()
        {
            this.PostedCrits = new HashSet<Crit>();
            this.Following = new HashSet<User>();
        }
        [InverseProperty("AuthorUser")]
        public virtual ICollection<Crit> PostedCrits
        {
            get { return this._postedCrits; }
            set { this._postedCrits = value; }
        }
        [InverseProperty("Users")]
        public virtual ICollection<Group> Groups { get; set; }
        public virtual ICollection<User> Following { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public string Bio { get; set; }
        public string FullName { get; set; }
        public string AvatarUrl { get; set; }
    }
}
