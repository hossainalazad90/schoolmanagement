using System;
using System.Collections.Generic;

namespace SchoolManagementApp.Models
{
    public partial class Districts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? Population { get; set; }
        public int StateId { get; set; }

        public virtual States State { get; set; }
    }
}
