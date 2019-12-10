using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Models
{
    public partial class Upazilas
    {
        public Upazilas()
        {
            UnionPorisods = new HashSet<UnionPorisods>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Population { get; set; }
        public int DistrictId { get; set; }

        public virtual States District { get; set; }
        public virtual ICollection<UnionPorisods> UnionPorisods { get; set; }
    }
}
