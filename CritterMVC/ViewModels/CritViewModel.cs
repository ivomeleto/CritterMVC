using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CritterMVC.ViewModels
{
    public class CritViewModel
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public UserViewModel Author { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
