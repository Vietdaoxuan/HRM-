﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRM.Models
{
    public class LSBankModel
    {
        public string LSBankID { get; set; }
        public string LSBankCode { get; set; }
        public string Name { get; set; }
        public string VNName { get; set; }
        public int Rank { get; set; }
        public string Note { get; set; }
        public bool Used { get; set; }
    }
}