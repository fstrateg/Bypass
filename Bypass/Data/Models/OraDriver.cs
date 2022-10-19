using System;
using System.Collections.Generic;
using System.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.Data;
using Bypass.Data.Types;

namespace Bypass.Models
{
    public class OraDriver
    {
        const int _fetchRowsAmount = 2048;

        OracleConnection _con = new OracleConnection();
        StringBuilder _sql=new StringBuilder();
        public OraDriver Dbo { get { return this; } }

       /* public OraDriver(Connect con)
        {
            OracleConnectionStringBuilder cb = new OracleConnectionStringBuilder();
            cb.UserID = con.UserName;
            cb.Password = con.Password;
            cb.DataSource = con.DataSource;
            _con.ConnectionString = cb.ToString();
        }*/

        public OraDriver Connect()
        {
            
            _con.Open();
            return this;
        }

        public OraDriver SetQuery(string sql)
        {
            _sql.Append(sql);
            return this;
        }

        public OracleDataReader GetReader()
        {
            OracleCommand cmd = new OracleCommand(_sql.ToString(), _con);
            return cmd.ExecuteReader();
        }
        
        public DataTable GetTable()
        {
            DataTable dt = new DataTable();
            OracleCommand cmd = new OracleCommand(_sql.ToString(), _con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTable(string StoredProc, string Param)
        {
            OracleDataReader rd = getDataReaderFromStoredProcedure(StoredProc, Param);
            if (rd != null)
            {
                DataTable table = new DataTable("rez");
                table.Load(rd);
                return table;
            }
            else return null;
        }

        public OracleDataReader getDataReaderFromStoredProcedure(string StoredProc, string Params)
        {
            _sql.Clear();
            this.SetQuery(StoredProc);
            string query = _sql.ToString();
            if (string.IsNullOrEmpty(query))
                throw new Exception("Запрос не задан!");
            //DataTable table = new DataTable(TableName);
            OracleCommand cmd = _con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = query;
            var param = new OracleParameter();
            param.OracleDbType = OracleDbType.RefCursor;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
            param = new OracleParameter();
            param.OracleDbType = OracleDbType.Clob;
            param.Direction = ParameterDirection.Input;
            param.Value = Params;
            cmd.Parameters.Add(param);

            OracleDataReader rdr = cmd.ExecuteReader();
            if (rdr.RowSize > 0) rdr.FetchSize = rdr.RowSize * _fetchRowsAmount;
            return rdr;
            
        }



        public void Close()
        {
            _con.Close();
        }
    }
}
