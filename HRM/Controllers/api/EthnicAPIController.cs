using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HRM.Controllers.api
{
    public class EthnicAPIController : ApiController
    {
        public IHttpActionResult GetData()
        {
            DataAccessLayer act = new DataAccessLayer();
            LSEthnicModel Ethnic = new LSEthnicModel();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ACTION","SelectAll")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSEthnic", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPost]
        public IHttpActionResult Create(LSEthnicModel Ethnic)
        {
            DataAccessLayer act = new DataAccessLayer();
            Ethnic.LSEthnicID = act.getOutPut("sp_AutoGenID_Ethnic", "@LSEthnicID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = Ethnic.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@LSEthnicCode",SqlDbType.NVarChar,15){ Value = Ethnic.LSEthnicCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = Ethnic.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = Ethnic.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = Ethnic.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = Ethnic.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = Ethnic.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSEthnic", parameters);
            return Ok();
        }

        public IHttpActionResult GetDataByID(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSEthnicModel Ethnic = new LSEthnicModel();
            Ethnic.LSEthnicID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = Ethnic.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSEthnic", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPut]
        public IHttpActionResult Update(LSEthnicModel Ethnic, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            Ethnic.LSEthnicID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = Ethnic.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@LSEthnicCode",SqlDbType.NVarChar,15){ Value = Ethnic.LSEthnicCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = Ethnic.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = Ethnic.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = Ethnic.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = Ethnic.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = Ethnic.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSEthnic", parameters);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSEthnicModel Ethnic = new LSEthnicModel();
            Ethnic.LSEthnicID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSEthnicID",SqlDbType.NVarChar,12){ Value = Ethnic.LSEthnicID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSEthnic", parameters);
            return Ok();
        }
    }
}
