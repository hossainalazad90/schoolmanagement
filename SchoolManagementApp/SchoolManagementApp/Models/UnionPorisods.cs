using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Models
{
    public partial class UnionPorisods
    {
        public UnionPorisods()
        {
            Villages = new HashSet<Villages>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Population { get; set; }
        public int UpazilaId { get; set; }

        public virtual Upazilas Upazila { get; set; }
        public virtual ICollection<Villages> Villages { get; set; }
    }
}
