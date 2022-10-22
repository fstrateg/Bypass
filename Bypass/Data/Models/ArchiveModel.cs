using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Models
{
    public class ArchiveModel : IArchiveModel
    {
        public ArchiveForm Filter { get; set; }
        public IEnumerable<BypassItem> Records { get; set; }

        public ArchiveModel()
        {
            Records = new List<BypassItem>();
        }
        public void Fetch()
        {
            throw new System.NotImplementedException();
        }
    }
}
