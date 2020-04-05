﻿using HRM.Models;
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
    public class MaritalAPIController : ApiController
    {
        public IHttpActionResult GetData()
        {
            DataAccessLayer act = new DataAccessLayer();
            LSMaritalModel Marital = new LSMaritalModel();
            SqlParameter[] parameters =
            {
                new SqlParameter("@ACTION","SelectAll")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSMarital", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPost]
        public IHttpActionResult Create(LSMaritalModel Marital)
        {
            DataAccessLayer act = new DataAccessLayer();
            Marital.LSMaritalID = act.getOutPut("sp_AutoGenID_Marital", "@LSMaritalID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = Marital.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@LSMaritalCode",SqlDbType.NVarChar,15){ Value = Marital.LSMaritalCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = Marital.Name ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = Marital.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = Marital.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Insert")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSMarital", parameters);
            return Ok();
        }

        public IHttpActionResult GetDataByID(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSMaritalModel Marital = new LSMaritalModel();
            Marital.LSMaritalID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = Marital.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","SelectByID")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSMarital", parameters);
            var Object = act.ConvertDataTableToJSON(ds.Tables[0]);
            return Ok(Object);
        }

        [HttpPut]
        public IHttpActionResult Update(LSMaritalModel Marital, string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            Marital.LSMaritalID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = Marital.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@LSMaritalCode",SqlDbType.NVarChar,15){ Value = Marital.LSMaritalCode ?? (object)DBNull.Value},
                new SqlParameter("@Name",SqlDbType.NVarChar,150){ Value = Marital.Name ?? (object)DBNull.Value},
                new SqlParameter("@Rank",SqlDbType.SmallInt){ Value = Marital.Rank.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@Used",SqlDbType.Bit){ Value = Marital.Used.ToString() ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Update")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSMarital", parameters);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Delete(string id)
        {
            DataAccessLayer act = new DataAccessLayer();
            LSMaritalModel Marital = new LSMaritalModel();
            Marital.LSMaritalID = id;
            SqlParameter[] parameters =
            {
                new SqlParameter("@LSMaritalID",SqlDbType.NVarChar,12){ Value = Marital.LSMaritalID ?? (object)DBNull.Value},
                new SqlParameter("@ACTION","Delete")
            };
            DataSet ds = act.Generic("sp_InsertUpdateDelete_tblLSMarital", parameters);
            return Ok();
        }
    }
}
