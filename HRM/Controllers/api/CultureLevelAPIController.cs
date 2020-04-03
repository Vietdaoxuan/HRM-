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
    public class CultureLevelAPIController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            DataAccessLayer act = new DataAccessLayer();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ACTION","GetData")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCultureLevel", parameters);
            var obj = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(obj);
        }

        [HttpPost]
        public IHttpActionResult Create(LSCultureLevelModel CulLevel)
        {
            DataAccessLayer act = new DataAccessLayer();
            CulLevel.LSCultureLevelID = act.getOutPut("sp_AutoGenID_CultureLevel", "@LSCultureLevelID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = CulLevel.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@LSCultureLevelCode",SqlDbType.NVarChar,15){ Value = CulLevel.LSCultureLevelCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = CulLevel.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = CulLevel.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = CulLevel.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = CulLevel.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = CulLevel.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCultureLevel", parameters);
            return Ok();
        }

        public IHttpActionResult GetDataByID(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSCultureLevelModel CulLevel = new LSCultureLevelModel();
            CulLevel.LSCultureLevelID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,100){ Value = CulLevel.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCultureLevel", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }
        [HttpPut]
        public IHttpActionResult Update(LSCultureLevelModel CulLevel, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            CulLevel.LSCultureLevelID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = CulLevel.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@LSCultureLevelCode",SqlDbType.NVarChar,15){ Value = CulLevel.LSCultureLevelCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = CulLevel.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = CulLevel.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = CulLevel.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = CulLevel.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = CulLevel.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCultureLevel", parameters);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSCultureLevelModel CulLevel = new LSCultureLevelModel();
            CulLevel.LSCultureLevelID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSCultureLevelID",SqlDbType.NVarChar,12){ Value = CulLevel.LSCultureLevelID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            act.Generic("sp_InsertUpdateDelete_tblLSCultureLevel", parameters);
            return Ok();
        }
    }
}
