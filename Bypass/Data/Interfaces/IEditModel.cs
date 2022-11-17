using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Interfaces
{
    public interface IEditModel
    {
        List<SprItem> SprEmployee();
        List<SprItem> SprEvents();
        List<DocParams> SprProps(string DocID);

        DocBypass GetBypass(string documentID);
        void SetConfiguration(Connect connect);
    }
}
