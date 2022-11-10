using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Mocks
{
    public class MockEdit : Interfaces.IEditModel
    {
        public IList<SprItem> SprEvent { get; set; }

        public void Init(string id)
        {
            SprEvent = new List<SprItem>();
            SprEvent.Add(new SprItem() { Id = "1", Name = "увольнение" });
            SprEvent.Add(new SprItem() { Id = "2", Name = "по собственному" });
            SprEvent.Add(new SprItem() { Id = "3", Name = "в резерв" });
            SprEvent.Add(new SprItem() { Id = "4", Name = "в запас" });
        }

        public void SetConfiguration(Connect connect)
        {
            
        }
    }
}
