using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Models
{
    public partial class Wards
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Population { get; set; }
        public int VillageId { get; set; }

        public virtual Villages Village { get; set; }
    }
}
