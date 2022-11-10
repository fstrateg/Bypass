using Bypass.Data.Types;
using System.Collections.Generic;
using Bypass.Data.Interfaces;

namespace Bypass.Data.Models
{
    public class EditModel: IEditModel
    {
        Connect _connect;
        public IList<SprItem> SprEvent { get; set; }

        public void Init(string id)
        {
            SprEvent= new List<SprItem>();
        }

        public void SetConfiguration(Connect connect)
        {
            _connect = connect;
        }
    }
}
