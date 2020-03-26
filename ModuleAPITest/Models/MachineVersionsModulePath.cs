using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models
{
    public partial class MachineVersionsModulePath
    {
        public int Id { get; set; }
        public int MachineVersionsId { get; set; }
        public int ModulePathId { get; set; }

        public virtual MachineVersions MachineVersions { get; set; }
        public virtual ModulePath ModulePath { get; set; }
    }
}
