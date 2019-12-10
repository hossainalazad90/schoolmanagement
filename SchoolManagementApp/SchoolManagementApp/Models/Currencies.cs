using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Models
{
    public partial class Currencies
    {
        public Currencies()
        {
            Countries = new HashSet<Countries>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal? UsdollarValue { get; set; }

        public virtual ICollection<Countries> Countries { get; set; }
    }
}
