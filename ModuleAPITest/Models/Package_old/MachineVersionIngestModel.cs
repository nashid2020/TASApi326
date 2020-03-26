using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.Package_old
{
    public class MachineVersionIngestModel
    {
        public int Id { get; set; }
        public bool IsDefault { get; set; }
        public string Documentation { get; set; }
        public string CanonicalVersion { get; set; }
        public int MachineId { get; set; }
        public int VersionsId { get; set; }

        public virtual MachineIngestModel Machine { get; set; }
        public virtual VersionIngestModel1 Version { get; set; }
    }
}
