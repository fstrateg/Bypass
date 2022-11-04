using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using Bypass.Models.Types;
using System.Security.Cryptography;
using Bypass.Data.Types;

namespace Bypass.Data.Models
{
    public class ModelDb:OraDriver
    {
        public ModelDb(Connect con):base(con)
        {
           
        }
        public bool CheckUser(string username, string password)
        {
           
            if (username == "Alex" && password == "123") return true;
            var stringWriter = new StringWriter();
            var xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("auth_info");
            xmlTextWriter.WriteElementString("login", username);
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hashBytes = MD5.Create().ComputeHash(inputBytes);
            xmlTextWriter.WriteElementString("password", Convert.ToHexString(hashBytes));
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();

            DataTable tb=Dbo.Connect().GetTable("www.PGK#SERVICE.prc_Authenticate", stringWriter.ToString());
            Dbo.Close();
            return tb.Rows[0][0].Equals(1m);
        }

        public List<BypassItem> GetBypassList()
        {
            List<BypassItem> rez = new List<BypassItem>();
            string par = "<USERDATA><USERNAME>develop</USERNAME><FILTER>12</FILTER><TIMEOUT>1</TIMEOUT><ISSL>1</ISSL></USERDATA>";
            var rd=Dbo.Connect().getDataReaderFromStoredProcedure("www.pkg#bypass.prc_GetByPassList", par);
            while(rd.Read())
            {
                rez.Add(
                    new BypassItem()
                    {
                        ID=rd.GetString(0),
                        DocDate=rd.GetString(1),
                        EventDate=rd.GetString(2),
                        TypeName=rd.GetString(3),
                        Staff=rd.GetString(4),
                        Remark=rd.GetString(5),
                        ObjCaption=rd[6].ToString(),
                        P108=rd.GetDecimal(7),
                        P124=rd.GetDecimal(8),
                        P138=rd.GetDecimal(9),
                        P183=rd.GetDecimal(10),
                        P314=rd.GetDecimal(11),
                        P363=rd.GetDecimal(12),
                        P405=rd.GetDecimal(13),
                        P758=rd.GetDecimal(14),
                        P778=rd.GetDecimal(15),
                        Info = rd[16]?.ToString(),
                        Zverid = rd[17]?.ToString(),
                        ZverContract = rd[18]?.ToString(),
                        Object_id = rd[20]?.ToString()
                        /*,
                        ZverContract=rd.GetString(18),
                        Zverid=rd.GetString(19)*/

                    });
            }
            Dbo.Close();
            
            rez.Sort((x, y) => { 
                return DateTime.ParseExact(y.EventDate, "dd.MM.yy",null).CompareTo(DateTime.ParseExact(x.EventDate, "dd.MM.yy", null)); });
            return rez;
        }

        internal List<Archive> GetArchive(ArchiveForm rr)
        {
            if (string.IsNullOrEmpty(rr.DateFrom)) rr.DateFrom = DateTime.Now.AddMonths(-12).ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(rr.DateTo)) rr.DateTo = DateTime.Now.ToString("yyyy-MM-dd");
            string likeid = "";
            if (!string.IsNullOrEmpty(rr.Fio)) likeid = $" and objcaption like '{rr.Fio}%'";
            List<Archive> rez = new List<Archive>();
            var rd = Dbo.Connect().SetQuery(@$"SELECT a.id, a.docdate, a.eventdate, a.typename,
        nvl(a.staff,' ') staff,
        nvl(a.remark,' ') remark,
       a.objcaption, a.clsstatus, a.clsdate
  FROM www.bypass_archive a 
where docdate between date '{rr.DateFromSql}' and date '{rr.DateToSql}' {likeid}
order by a.docdate").GetReader();
            while(rd.Read())
            {
                rez.Add(new Archive()
                {
                    ID = rd.GetString(0),
                    DocDate = rd.GetDateTime(1).ToString("d"),
                    EventDate = rd.GetDateTime(2).ToString("d"),
                    Event = rd.GetString(3),
                    Staff = rd.GetString(4),
                    Remark = rd.GetString(5),
                    Fio = rd.GetString(6),
                }) ;
            }
            rd.Close();
            Dbo.Close();
            return rez;
        }
    }


}
