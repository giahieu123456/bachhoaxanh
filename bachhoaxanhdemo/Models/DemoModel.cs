using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bachhoaxanhdemo.Models
{
    public class DemoModel
    {

        public int idProduct { get; set; }
        public string productName { get; set; }
        public Nullable<double> productPrice { get; set; }
        public string tradeMark { get; set; }
        public string madeIn { get; set; }
        public string ingredient { get; set; }
        public string howToUse { get; set; }
        public Nullable<double> weight { get; set; }
        public string preservation { get; set; }
        public string decription { get; set; }
        public string image { get; set; }
        public Nullable<int> idProductTitle { get; set; }
        public int idCategory { get; set; }
       
    }
}