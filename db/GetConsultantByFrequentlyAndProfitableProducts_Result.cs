//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesManagementSystem.db
{
    using System;
    
    public partial class GetConsultantByFrequentlyAndProfitableProducts_Result
    {
        public Nullable<int> ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public string ConsultantSurname { get; set; }
        public string ConsultantIdNumber { get; set; }
        public Nullable<System.DateTime> ConsultantDateOfBirth { get; set; }
        public Nullable<int> FrequentlySoldProductCode { get; set; }
        public string FrequentlySoldProductName { get; set; }
        public Nullable<decimal> FrequentlySoldProductTotalPrice { get; set; }
        public Nullable<int> ProfitableProductCode { get; set; }
        public string ProfitableProductName { get; set; }
        public Nullable<decimal> ProfitableProductTotalPrice { get; set; }
    }
}
