using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.DB
{
    public partial class MachineVersions
    {
        public MachineVersions()
        {
            MachineVersionsModulePath = new HashSet<MachineVersionsModulePath>();
        }

        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public string Documentation { get; set; }
        public string CanonicalVersion { get; set; }
        public int MachineId { get; set; }
        public int VersionsId { get; set; }

        public virtual Machine Machine { get; set; }
        public virtual Versions Versions { get; set; }
        public virtual ICollection<MachineVersionsModulePath> MachineVersionsModulePath { get; set; }
    }
}
