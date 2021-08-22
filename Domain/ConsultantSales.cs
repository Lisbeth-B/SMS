using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesManagementSystem.Domain
{
    public class ConsultantSales
    {
        public ConsultantSales(int? consultantId, string consultantName, string consultantSurname, string consultantIdNumber, DateTime? consultantDateOfBirth, decimal? sales, decimal? totalSales)
        {
            ConsultantId = consultantId;
            ConsultantName = consultantName;
            ConsultantSurname = consultantSurname;
            ConsultantIdNumber = consultantIdNumber;
            ConsultantDateOfBirth = consultantDateOfBirth;
            Sales = sales;
            TotalSales = totalSales;
        }

        public Nullable<int> ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantSurname { get; set; }
        public string ConsultantIdNumber { get; set; }
        public Nullable<System.DateTime> ConsultantDateOfBirth { get; set; }
        public Nullable<decimal> Sales { get; set; }
        public Nullable<decimal> TotalSales { get; set; }
    }
}