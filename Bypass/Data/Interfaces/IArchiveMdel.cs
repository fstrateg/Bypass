using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Interfaces
{
    public interface IArchiveModel
    {
        IEnumerable<BypassItem> Records { get; set; }

        void Fetch();

        ArchiveForm Filter { get; set; }

    }
}
