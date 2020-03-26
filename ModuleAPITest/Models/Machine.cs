using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.DB
{
    public partial class Machine
    {
        public Machine()
        {
            MachineVersions = new HashSet<MachineVersions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MachineVersions> MachineVersions { get; set; }
    }
}
