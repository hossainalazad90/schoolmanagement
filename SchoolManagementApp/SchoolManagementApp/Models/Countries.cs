using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Models
{
    public partial class Countries
    {
        public Countries()
        {
            States = new HashSet<States>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Area { get; set; }
        public int? Population { get; set; }
        public string Capital { get; set; }
        public int CurrencyId { get; set; }
        public string Isocode2 { get; set; }
        public string Isocode3 { get; set; }

        public virtual Currencies Currency { get; set; }
        public virtual ICollection<States> States { get; set; }
    }
}
