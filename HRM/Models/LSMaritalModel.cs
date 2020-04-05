using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class LSMaritalModel
    {
        public string LSMaritalID { get; set; }
        public string LSMaritalCode { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public bool Used { get; set; }
    }
}