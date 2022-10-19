using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Interfaces
{
    public interface IBypassItems
    {
        IEnumerable<BypassItem> GetAllItems();
    }
}
