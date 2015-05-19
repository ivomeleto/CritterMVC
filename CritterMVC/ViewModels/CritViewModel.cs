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
        public User Author { get; set; }
        public User Recipient { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
