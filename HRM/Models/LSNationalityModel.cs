using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class LSNationalityModel
    {
        public string LSNationalityID { get; set; }
        public string LSNationalityCode { get; set; }
        public string Name { get; set; }
        public string VNName { get; set; }
        public int Rank { get; set; }
        public string Note { get; set; }
        public bool Used { get; set; }
    }
}