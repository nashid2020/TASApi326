using System;
using System.Collections.Generic;

namespace ModuleAPITest.Models.DB
{
    public partial class Package
    {
        public Package()
        {
            Versions = new HashSet<Versions>();
        }

        public int Id { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }
        public virtual ICollection<Versions> Versions { get; set; }
    }
}
