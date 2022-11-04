using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using Bypass.Models.Types;
using System.Collections.Generic;

namespace Bypass.Data.Mocks
{
    public class MockArchive : IArchiveModel
    {
        public void SetConfiguration(Connect conect)
        {

        }
        public ArchiveForm Filter { get; set; }
        public IEnumerable<Archive> Data { get; set; }

        public MockArchive()
        {
            Data = new List<Archive>();
        }
        public void Fetch()
        {
            List<Archive> rez =new List<Archive>();
            MockBypass mm = new MockBypass();
            var rd = mm.GetAllItems();
            foreach(var item in rd)
            {
                rez.Add(new Archive()
                {
                    Event        = item.TypeName,
                    EventDate    = item.EventDate,
                    Fio          = item.ObjCaption,
                    Staff        = item.Staff,
                    DocDate      = item.DocDate,
                    Remark       = item.Remark,
                    ID           = "0",
                    
                });
            }
            Data = rez;
        }
    }
}
