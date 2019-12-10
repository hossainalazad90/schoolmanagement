using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Models
{
    public partial class States
    {
        public States()
        {
            Districts = new HashSet<Districts>();
            Upazilas = new HashSet<Upazilas>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }
        public int? Population { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Districts> Districts { get; set; }
        public virtual ICollection<Upazilas> Upazilas { get; set; }
    }
}
