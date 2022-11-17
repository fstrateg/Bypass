using Bypass.Data.Types;
using System.Collections.Generic;
using Bypass.Data.Interfaces;
using System.IO;
using System.Xml;
using System;

namespace Bypass.Data.Models
{
    public class EditModel: IEditModel
    {
        const string MODGUID = "59E9EB91C4EB49CCAE6F5775850952FC";
        Connect _connect;

        public List<SprItem> SprEmployee()
        {
            return fetchItems("www.PKG#COMMON.prc_GetITREmployeeList", string.Empty);
        }

        public List<SprItem> SprEvents()
        {
            return fetchItems("www.PKG#COMMON.prc_GetByPassTypeList", string.Empty);
        }

        public List<DocParams> SprProps(string DocID)
        {
            StringWriter stringWriter = new StringWriter();
            XmlWriter xmlTextWriter = XmlWriter.Create(stringWriter);
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("USERDATA");
            xmlTextWriter.WriteElementString("GUID", MODGUID);
            if (!String.IsNullOrEmpty(DocID))
                xmlTextWriter.WriteElementString("DOCBYPASSID", DocID);
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();

            ModelDb db = new ModelDb(_connect);
            db.Connect();
            List<DocParams> rez = new List<DocParams>();
            using (var rd = db.getDataReaderFromStoredProcedure("www.PKG#COMMON.prc_GetModuleParamList", stringWriter.ToString()))
            {
                while (rd.Read())
                {
                    rez.Add(new DocParams()
                    {
                        ParamID = rd.GetString(0),
                        Incode = rd.GetString(1),
                        Name = rd.GetString(2),
                        Selected = rd.GetInt32(3)
                    });
                }
                rd.Close();
            }
            return rez;
        }

        public DocBypass GetBypass(string documentID)
        {
            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            xmlTextWriter.Formatting = Formatting.Indented;
            xmlTextWriter.WriteStartDocument();
            xmlTextWriter.WriteStartElement("USERDATA");
            xmlTextWriter.WriteElementString("BYPASSDOCID", documentID);
            xmlTextWriter.WriteEndElement();
            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
            ModelDb db = new ModelDb(_connect);
            db.Connect();
            DocBypass rez = new DocBypass();
            using (var rd = db.getDataReaderFromStoredProcedure("www.PKG#BYPASS.prc_GetByPass", stringWriter.ToString()))
            {
                if (rd.Read())
                {
                    rez.Object_id = rd.GetString(0);
                    rez.EventDate = rd.GetDateTime(2);
                    rez.Type_id = rd.GetString(3);
                    rez.Remark = rd.GetString(4);
                }
                rd.Close();
            }
            return rez;
        }

        private List<SprItem> fetchItems(string proc, string param)
        {
            ModelDb db = new ModelDb(_connect);
            db.Connect();
            List<SprItem> rez = new List<SprItem>();
            using (var rd = db.getDataReaderFromStoredProcedure(proc, param))
            {
                while (rd.Read())
                {
                    rez.Add(new SprItem()
                    {
                        Id = rd.GetString(0),
                        Name = rd.GetString(1)
                    });
                }
                rd.Close();
            }
            return rez;
        }

        public void SetConfiguration(Connect connect)
        {
            _connect = connect;
        }
    }
}
