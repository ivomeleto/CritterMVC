using Critter.Models;
using System;
using System.Collections.Generic;
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
        public UserViewModel Author { get; set; }
        public DateTime CreatedAt { get; set; }


        public static Expression<Func<Crit,CritViewModel>>  ViewMidel  //TODO:get real familiar with the Expressions
        {
            get
            {
                return x => new CritViewModel
                {
                    Id = x.CritId,
                    Text = x.Text,
                    CreatedAt = x.CreatedAt
                };
            }
        }
    }
}
