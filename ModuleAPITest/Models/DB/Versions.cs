using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.DB
{
    public partial class Versions
    {
        public Versions()
        {
            MachineVersions = new HashSet<MachineVersions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PackageId { get; set; }

        public virtual Package Package { get; set; }
        public virtual ICollection<MachineVersions> MachineVersions { get; set; }
    }
}
