using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class EmployeeModel
    {
        public string EmpID { get; set; }

        public string EmpCode { get; set; }

        public string EmpCodeOld { get; set; }

        public string StartDate { get; set; }

        public string LSCompanyID { get; set; }

        public string LSLevel1ID { get; set; }

        public string LSLevel2ID { get; set; }

        public string LSLevel3ID { get; set; }

        public string LSLevel4ID { get; set; }

        public string LSPositionID { get; set; }

        public string LSJobTitleID { get; set; }

        public string LSLocationID { get; set; }

        public string LSEmpTypeID { get; set; }

        public bool Active { get; set; }

        public string Creater { get; set; }

        public string CreateTime { get; set; }

        public string Editer { get; set; }

        public string EditTime { get; set; }
    }
}