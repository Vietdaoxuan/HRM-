using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HRM.Models
{
    public class DataAccessLayer
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        /// <summary>
        /// Generic operation
        /// </summary>
        /// <param name="spname">Stored Proedure name</param>
        /// <param name="prms">parameters in Stored Procedure</param>
        /// <returns></returns>
        public DataSet Generic(string spname, SqlParameter[] prms = null)
        {
            DataSet ds = new DataSet();
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(spname, conn);
            if (prms != null)
            {
                cmd.Parameters.AddRange(prms);
            }
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;
        }

        /// <summary>
        /// Get Output Parameters from Stored Procedure
        /// </summary>
        /// <param name="sp_name">Stored Proedure name</param>
        /// <param name="prms_sp">parameters in Stored Procedure</param>
        /// <returns></returns>
        public string getOutPut(string sp_name, string prms_sp)
        {
            string result;
            SqlConnection conn = new SqlConnection(ConnectionString);
            using (SqlCommand cmd = new SqlCommand(sp_name, conn))
            {
                try
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter prms = new SqlParameter(prms_sp, SqlDbType.NVarChar, 12);
                    prms.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(prms);   
                    cmd.ExecuteNonQuery();
                    result = cmd.Parameters[prms_sp].Value.ToString();
                }
                catch (Exception ex)
                {
                    string msg = ex.ToString();
                    result = "";
                }
            }
            return result;
        }

        public SelectList ToSelectList(string valueField, string textField, string sql = null)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlDataAdapter adpt = new SqlDataAdapter(sql, conn);
            DataTable table = new DataTable();
            adpt.Fill(table);
            List<SelectListItem> list = new List<SelectListItem>();
            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }
            return new SelectList(list, "Value", "Text");
        }

        public object ConvertDataTableToJSON(DataTable dt)
        {
            JavaScriptSerializer jSonString = new JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            string serialize = jSonString.Serialize(rows);
            var data = jSonString.Deserialize<IEnumerable<object>>(serialize);
            return data;
        }
    }
}

