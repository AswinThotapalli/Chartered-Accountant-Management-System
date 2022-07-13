using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CharteredAccountantsFYP.Models
{
    public class ClientsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BusinessType { get; set; }
        public string BusinessTypeInline 
        {
            get
            {
                if (BusinessType == 1)
                {
                    return "Company";
                }
                else if (BusinessType == 2)
                {
                    return "Individuals";
                }
                else if (BusinessType == 3)
                {
                    return "Sole Properietor";
                }
                else if (BusinessType == 4)
                {
                    return "Associates";
                }
                else if (BusinessType == 5)
                {
                    return "Trust";
                }
                else
                {
                    return "";
                }
            }
        }

        public int? TypeOfCompany { get; set; }
        public string TypeOfCompanyInline 
        {
            get
            {
                if (TypeOfCompany == 1)
                {
                    return "Public";
                }
                else if (TypeOfCompany == 2)
                {
                    return "Private";
                }
                else if (TypeOfCompany == 3)
                {
                    return "SMC";
                }
                else
                {
                    return "";
                }
            }
        }
        public int LimitedBy { get; set; }
        public string LimitedByInline
        {
            get
            {
                if (LimitedBy == 1)
                {
                    return "Share";
                }
                else if (LimitedBy == 2)
                {
                    return "Guarantee";
                }
                else
                {
                    return "";
                }
            }
        }
        public double? ShareValue1 { get; set; }
        public double? ShareValue2 { get; set; }
        public double? ProductOfShareValues { get; set; }
        public string BusinessObjectives { get; set; }
        public string CNIC { get; set; }
        public string IncorporationNo { get; set; }
        public int? PINCode { get; set; }
        public int? FBRLogin { get; set; }
        public string FBRPassword { get; set; }
        public string NTN { get; set; }
        public string RegistrationNo { get; set; }
        public string RegisteredWith { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string FaxNo { get; set; }
        public bool? ServiceAudit { get; set; }
        public bool? ServiceCorporate { get; set; }
        public bool? ServiceAccounting { get; set; }
        public bool? ServiceLegal { get; set; }
        public bool? ServiceTaxation { get; set; }

        public long CreatedBy { get; set; }
        public long CreatedDate { get; set; }
        public long UpdatedById { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int YearId { get; set; }
        public int Year { get; set; } 
        public int UserId { get; set; }
        public string FilePathNew { get; set; }
        public string FilePathOld { get; set; }
        public string LastChanges { get; set; }


    }
}