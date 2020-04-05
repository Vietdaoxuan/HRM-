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
    public class ProvinceAPIController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            DataAccessLayer act = new DataAccessLayer();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ACTION","GetData")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSProvince", parameters);
            var obj = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(obj);
        }

        [HttpPost]
        public IHttpActionResult Create(LSProvince Province)
        {
            DataAccessLayer act = new DataAccessLayer();
            Province.LSProvinceID = act.getOutPut("sp_AutoGenID_Province", "@LSProvinceID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSProvinceID",SqlDbType.NVarChar,12){ Value = Province.LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@LSProvinceCode",SqlDbType.NVarChar,15){ Value = Province.LSProvinceCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = Province.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = Province.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = Province.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = Province.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = Province.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSProvince", parameters);
            return Ok();
        }

        public IHttpActionResult GetDataByID(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSProvince Province = new LSProvince();
            Province.LSProvinceID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSProvinceID",SqlDbType.NVarChar,100){ Value = Province.LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSProvince", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }
        [HttpPut]
        public IHttpActionResult Update(LSProvince Province, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            Province.LSProvinceID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSProvinceID",SqlDbType.NVarChar,12){ Value = Province.LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@LSProvinceCode",SqlDbType.NVarChar,15){ Value = Province.LSProvinceCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = Province.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = Province.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = Province.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = Province.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = Province.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSProvince", parameters);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSProvince Province = new LSProvince();
            Province.LSProvinceID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSProvinceID",SqlDbType.NVarChar,12){ Value = Province.LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            act.Generic("sp_InsertUpdateDelete_tblLSProvince", parameters);
            return Ok();
        }
    }
}
