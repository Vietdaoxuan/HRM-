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
    public class BankAPIController : ApiController
    {
        public IHttpActionResult GetData()
        {
            DataAccessLayer act = new DataAccessLayer();
            LSBankModel bank = new LSBankModel();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ACTION","SelectAll")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSBank", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPost]
        public IHttpActionResult Create(LSBankModel bank)
        {
            DataAccessLayer act = new DataAccessLayer();
            bank.LSBankID = act.getOutPut("sp_AutoGenID_Bank", "@LSBankID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = bank.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@LSBankCode",SqlDbType.NVarChar,15){ Value = bank.LSBankCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = bank.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = bank.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = bank.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = bank.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = bank.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSBank", parameters);
            return Ok();
        }

        public IHttpActionResult GetDataByID(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSBankModel bank = new LSBankModel();
            bank.LSBankID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = bank.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSBank", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPut]
        public IHttpActionResult Update(LSBankModel bank, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            bank.LSBankID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = bank.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@LSBankCode",SqlDbType.NVarChar,15){ Value = bank.LSBankCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = bank.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = bank.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = bank.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = bank.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = bank.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSBank", parameters);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSBankModel bank = new LSBankModel();
            bank.LSBankID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSBankID",SqlDbType.NVarChar,12){ Value = bank.LSBankID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSBank", parameters);
            return Ok();
        }
    }
}
