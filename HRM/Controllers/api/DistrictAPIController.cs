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
    public class DistrictAPIController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            DataAccessLayer act = new DataAccessLayer();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ACTION","GetData")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSDistrict", parameters);
            var obj = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(obj);
        }

        [HttpPost]
        public IHttpActionResult Create(LSDistrict District)
        {
            DataAccessLayer act = new DataAccessLayer();
            District.LSDistrictID = act.getOutPut("sp_AutoGenID_District", "@LSDistrictID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSDistrictID",SqlDbType.NVarChar,12){ Value = District.LSDistrictID ?? (object)DBNull.Value},
                new SqlParameter("@LSDistrictCode",SqlDbType.NVarChar,15){ Value = District.LSDistrictCode ?? (object)DBNull.Value},
                new SqlParameter("@LSProvinceID",SqlDbType.NVarChar,12){ Value = District.LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = District.Name ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = District.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = District.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = District.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSDistrict", parameters);
            return Ok();
        }

        public IHttpActionResult GetDataByID(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSDistrict District = new LSDistrict();
            District.LSDistrictID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSDistrictID",SqlDbType.NVarChar,100){ Value = District.LSDistrictID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSDistrict", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }
        [HttpPut]
        public IHttpActionResult Update(LSDistrict District, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            District.LSDistrictID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSDistrictID",SqlDbType.NVarChar,12){ Value = District.LSDistrictID ?? (object)DBNull.Value},
                new SqlParameter("@LSDistrictCode",SqlDbType.NVarChar,15){ Value = District.LSDistrictCode ?? (object)DBNull.Value},
                new SqlParameter("@LSProvinceID",SqlDbType.NVarChar,12){ Value = District.LSProvinceID ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = District.Name ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = District.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = District.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = District.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSDistrict", parameters);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSDistrict District = new LSDistrict();
            District.LSDistrictID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSDistrictID",SqlDbType.NVarChar,12){ Value = District.LSDistrictID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            act.Generic("sp_InsertUpdateDelete_tblLSDistrict", parameters);
            return Ok();
        }
    }
}
