using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.Package_old
{
    public partial class MachineVersion
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public string Documentation { get; set; }
        public string CanonicalVersion { get; set; }
        public int MachineId { get; set; }
        public int VersionsId { get; set; }

        public virtual Machine Machine { get; set; }
        public virtual Version Versions { get; set; }
    }
}
