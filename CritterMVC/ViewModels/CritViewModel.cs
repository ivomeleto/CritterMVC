using Critter.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.Ajax.Utilities;

namespace CritterMVC.ViewModels
{
    public class CritViewModel
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public User Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public string AuthorAvatar { get; set; }
        public int VotesCount { get; set; }

        public static CritViewModel ToViewModel(Crit crit)
        {
            return new CritViewModel()
            {
                Id = crit.CritId,
                Author = crit.AuthorUser,
                CreatedAt = crit.CreatedAt,
                Text = crit.Text,
                VotesCount = crit.Votes.Count
            };
        }
        public static Expression<Func<Crit, CritViewModel>> ViewModel
        {
            get
            {
                return x => new CritViewModel()
                {
                    Id = x.CritId,
                    Author = x.AuthorUser,
                    CreatedAt = x.CreatedAt,
                    Text = x.Text,
                    VotesCount = x.Votes.Count
                };
            }
        }

    }
}
