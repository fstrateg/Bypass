using Bypass.Data.Types;
using Bypass.Models.Types;
using System.Collections.Generic;

namespace Bypass.Data.Interfaces
{
    public interface IBypassItems
    {
        void SetConfiguration(Connect conect);
        IEnumerable<BypassItem> GetAllItems();
    }
}
