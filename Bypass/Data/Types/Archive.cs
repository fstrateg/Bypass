using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bypass.Models.Types
{
    public class Archive
    {
        public decimal ID { get; set; }
        public string Fio { get; set; }
        public string DocDate { get; set; }
        public string EventDate { get; set; }

        public string Staff { get; set; }
        public string Event { get; set; }

        public string Remark { get; set; }

    }
}
