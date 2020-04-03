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
    public class CompanyAPIController : ApiController
    {
        public IHttpActionResult GetData()
        {
            LSCompanyModel com = new LSCompanyModel();
            DataAccessLayer act = new DataAccessLayer();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ACTION","SelectAll")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCompany", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPost]
        public IHttpActionResult Create(LSCompanyModel com)
        {
            DataAccessLayer act = new DataAccessLayer();
            com.LSCompanyID = act.getOutPut("sp_AutoGenID_Company", "@LSCompanyID");
            SqlParameter[] parameters =
             {
                new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = com.LSCompanyID ?? (object)DBNull.Value},
                new SqlParameter("@LSCompanyCode",SqlDbType.NVarChar,15){ Value = com.LSCompanyCode ?? (object)DBNull.Value},
                new SqlParameter("@ShortName",SqlDbType.NVarChar,30){ Value = com.ShortName ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = com.Name ?? (object)DBNull.Value},
                new SqlParameter("@Address",SqlDbType.NVarChar,150){ Value = com.Address ?? (object)DBNull.Value},
                new SqlParameter("@Phone",SqlDbType.NVarChar,100){ Value = com.Phone ?? (object)DBNull.Value},
                new SqlParameter("@Fax",SqlDbType.NVarChar,100){ Value = com.Fax ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = com.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = com.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = com.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@WorkingPlace",SqlDbType.NVarChar,150){ Value = com.WorkingPlace ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,20){ Value = com.Creater ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,20){ Value = com.Editer ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCompany", parameters);
            return Ok();
        }

        public IHttpActionResult GetDataByID(string id)
        {
            LSCompanyModel com = new LSCompanyModel();
            DataAccessLayer act = new DataAccessLayer();
            com.LSCompanyID = id;
            SqlParameter[] parameters =
             {
                new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = com.LSCompanyID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };

            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCompany", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPut]
        public IHttpActionResult Update(string id, LSCompanyModel com)
        {
            DataAccessLayer act = new DataAccessLayer();
            com.LSCompanyID = id;
            SqlParameter[] parameters =
             {
                new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = com.LSCompanyID ?? (object)DBNull.Value},
                new SqlParameter("@LSCompanyCode",SqlDbType.NVarChar,15){ Value = com.LSCompanyCode ?? (object)DBNull.Value},
                new SqlParameter("@ShortName",SqlDbType.NVarChar,30){ Value = com.ShortName ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = com.Name ?? (object)DBNull.Value},
                new SqlParameter("@Address",SqlDbType.NVarChar,150){ Value = com.Address ?? (object)DBNull.Value},
                new SqlParameter("@Phone",SqlDbType.NVarChar,100){ Value = com.Phone ?? (object)DBNull.Value},
                new SqlParameter("@Fax",SqlDbType.NVarChar,100){ Value = com.Fax ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = com.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Note",SqlDbType.NVarChar,255){ Value = com.Note ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = com.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@WorkingPlace",SqlDbType.NVarChar,150){ Value = com.WorkingPlace ?? (object)DBNull.Value},
                new SqlParameter("@Creater",SqlDbType.NVarChar,20){ Value = com.Creater ?? (object)DBNull.Value},
                new SqlParameter("@Editer",SqlDbType.NVarChar,20){ Value = com.Editer ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSCompany", parameters);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSCompanyModel com = new LSCompanyModel();
            com.LSCompanyID = id;
            SqlParameter[] parameters =
             {
                new SqlParameter("@LSCompanyID",SqlDbType.NVarChar,12){ Value = com.LSCompanyID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            act.Generic("sp_InsertUpdateDelete_tblLSCompany", parameters);
            return Ok();
        }
    }
}
