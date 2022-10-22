using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Mocks
{
    public class MockArchive : IArchiveModel
    {
        public ArchiveForm Filter { get; set; }
        public IEnumerable<BypassItem> Records { get; set; }

        public MockArchive()
        {
            Records = new List<BypassItem>();
        }
        public void Fetch()
        {
            MockBypass mm = new MockBypass();
            Records = mm.GetAllItems();
        }

        public IEnumerable<BypassItem> FetchRecords()
        {
            MockBypass mm = new MockBypass();
            return mm.GetAllItems();
        }
    }
}
