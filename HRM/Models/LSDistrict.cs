using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class LSDistrict
    {
        public string LSDistrictID { get; set; }
        public string LSDistrictCode { get; set; }
        public string Name { get; set; }
        public string LSProvinceID { get; set; }
        public int Rank { get; set; }
        public string Note { get; set; }
        public bool Used { get; set; }
    }
}