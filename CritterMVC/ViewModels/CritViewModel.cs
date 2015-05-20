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

        public static CritViewModel ToViewModel(Crit crit)
        {
            return new CritViewModel()
            {
                Id = crit.CritId,
                Author = crit.AuthorUser,
                CreatedAt = crit.CreatedAt,
                Text = crit.Text
            };
        }

    }
}
