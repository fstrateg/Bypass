using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Interfaces
{
    public interface IEditModel
    {
        IList<SprItem> SprEvent { get; set; }
        void Init(string id);
        void SetConfiguration(Connect connect);
    }
}
