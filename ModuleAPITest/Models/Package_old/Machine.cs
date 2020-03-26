using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.Package_old
{
    public partial class Machine
    {
        public Machine()
        {
            MachineVersion = new HashSet<MachineVersion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MachineVersion> MachineVersion { get; set; }
    }
}
