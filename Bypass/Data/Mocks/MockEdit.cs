using Bypass.Data.Interfaces;
using Bypass.Data.Types;
using System.Collections.Generic;

namespace Bypass.Data.Mocks
{
    public class MockEdit : IEditModel
    {
        public DocBypass GetBypass(string documentID)
        {
            DocBypass rez = new DocBypass();
            return rez;
        }

        public void SetConfiguration(Connect connect)
        {
            
        }

        public List<SprItem> SprEmployee()
        {
            List<SprItem> rez = new List<SprItem>();
            rez.AddRange(new SprItem[]{
                    new SprItem() { Id = "1", Name = "Иванов" },
                    new SprItem() { Id = "2", Name = "Мужельских Алексей Юрьевич|1978" },
                    new SprItem() { Id = "3", Name = "Мужельских Александр Сергеевич|2000" }
                    }
                );
            return rez;
        }

        public List<SprItem> SprEvents()
        {
            List<SprItem>  SprEvent = new List<SprItem>();
            SprEvent.Add(new SprItem() { Id = "1", Name = "увольнение" });
            SprEvent.Add(new SprItem() { Id = "2", Name = "по собственному" });
            SprEvent.Add(new SprItem() { Id = "3", Name = "в резерв" });
            SprEvent.Add(new SprItem() { Id = "4", Name = "в запас" });
            return (List<SprItem>)SprEvent;
        }

        public List<DocParams> SprProps(string DocID)
        {
            List<DocParams> rez = new List<DocParams>();
            rez.Add(new DocParams()
            {
                ParamID= "10000000000000000050",
                Incode= "183",
                Name= "Центральный вычислительный центр Техническая служба",
                Selected=0
            });
            rez.Add(new DocParams()
            {
                ParamID = "10000000000000000052",
                Incode = "314",
                Name = "Центральный вычислительный центр Отдел информационный",
                Selected = 0
            });
            rez.Add(new DocParams()
            {
                ParamID = "10000000000000000053",
                Incode = "405",
                Name = "Центральный вычислительный центр Отдел производственный",
                Selected = 0
            });
            rez.Add(new DocParams()
            {
                ParamID = "10000000000000000054",
                Incode = "778",
                Name = "Центральный вычислительный центр Отдел ИБ",
                Selected = 0
            });
            rez.Add(new DocParams()
            {
                ParamID = "10000000000000000055",
                Incode = "363",
                Name = "IP-телефония",
                Selected = 1
            });
            return rez;
        }
    }
}
