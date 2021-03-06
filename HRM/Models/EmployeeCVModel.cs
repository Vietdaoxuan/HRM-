﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PagedList;

namespace HRM.Models
{
    public class EmployeeCVModel
    {
        public string EmpID { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Enter Last Name")]
        public string VLastName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Enter First Name")]
        public string VFirstName { get; set; }

        public string NickName { get; set; }

        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Enter DOB")]
        public string DOB { get; set; }

        [Required(ErrorMessage = "Enter Gender")]
        public string Gender { get; set; }

        public string LSMaritalID { get; set; }

        public string Born_District { get; set; }

        public string Born_LSProvinceID { get; set; }

        public string Native_District { get; set; }

        public string Native_LSProvinceID { get; set; }

        public string LSEthnicID { get; set; }

        public string IDNo { get; set; }

        public string IDIssuedDate { get; set; }

        public string IDIssuedPlace { get; set; }

        public string Mobifone { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string LSNationalityID { get; set; }

        public string LSCultureLevelID { get; set; }

        public string ScanCode { get; set; }

        public string Note { get; set; }

        public string Creater { get; set; }

        public string CreateTime { get; set; }

        public string Editer { get; set; }

        public string EditTime { get; set; }

        public string BankNo { get; set; }

        public string LSBankID { get; set; }

        public bool IsEmpBook { get; set; }

        public bool IsEmpCode { get; set; }

        public bool IsUniform { get; set; }

        public bool IsTrain { get; set; }

        [Display(Name = "Search For:")]
        public string searchtxt { get; set; }

        //public List<EmployeeCVModel> ShowallEmployee { get; set; }

    }
}