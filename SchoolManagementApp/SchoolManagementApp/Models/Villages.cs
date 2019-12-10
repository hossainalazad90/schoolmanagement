using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Models
{
    public partial class Villages
    {
        public Villages()
        {
            Wards = new HashSet<Wards>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Population { get; set; }
        public int UnionPorisodId { get; set; }

        public virtual UnionPorisods UnionPorisod { get; set; }
        public virtual ICollection<Wards> Wards { get; set; }
    }
}
