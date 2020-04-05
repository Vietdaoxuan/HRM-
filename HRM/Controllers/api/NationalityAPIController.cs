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
    public class NationalityAPIController : ApiController
    {
        public IHttpActionResult GetData()
        {
            DataAccessLayer act = new DataAccessLayer();
            LSNationalityModel Nationality = new LSNationalityModel();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ACTION","SelectAll")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSNationality", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPost]
        public IHttpActionResult Create(LSNationalityModel Nationality)
        {
            DataAccessLayer act = new DataAccessLayer();
            Nationality.LSNationalityID = act.getOutPut("sp_AutoGenID_Nationality", "@LSNationalityID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = Nationality.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@LSNationalityCode",SqlDbType.NVarChar,15){ Value = Nationality.LSNationalityCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = Nationality.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = Nationality.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = Nationality.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = Nationality.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = Nationality.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSNationality", parameters);
            return Ok();
        }

        public IHttpActionResult GetDataByID(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSNationalityModel Nationality = new LSNationalityModel();
            Nationality.LSNationalityID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = Nationality.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSNationality", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPut]
        public IHttpActionResult Update(LSNationalityModel Nationality, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            Nationality.LSNationalityID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = Nationality.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@LSNationalityCode",SqlDbType.NVarChar,15){ Value = Nationality.LSNationalityCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = Nationality.Name ?? (object)DBNull.Value},
                new SqlParameter("@VNName",SqlDbType.NVarChar,150){ Value = Nationality.VNName ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = Nationality.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = Nationality.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = Nationality.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSNationality", parameters);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSNationalityModel Nationality = new LSNationalityModel();
            Nationality.LSNationalityID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSNationalityID",SqlDbType.NVarChar,12){ Value = Nationality.LSNationalityID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSNationality", parameters);
            return Ok();
        }
    }
}
