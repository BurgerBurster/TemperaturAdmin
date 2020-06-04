using System;
using System.Collections.Generic;
using System.Text;

namespace TempAdmeme.Models
{
    public class MenuItem
    {
        public string Image { get; set; }
        public string Text { get; set; }
        public double Scale { get; set; } = 1;
        public Xamarin.Forms.Page Page { get; set; }
    }
}
