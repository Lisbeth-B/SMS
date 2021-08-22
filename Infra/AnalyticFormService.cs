using SalesManagementSystem.db;
using SalesManagementSystem.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;

namespace SalesManagementSystem.Infra
{
    public class AnalyticFormService : IOrderService
    {
        private readonly SalesManagementSystemEntities _dbContext;

        public AnalyticFormService(SalesManagementSystemEntities dbContext)
        {
            _dbContext = dbContext;
        }

        public ObjectResult<GetOrdersByConsultant_Result> GetOrdersByConsultant(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate)
        {
            return _dbContext.GetOrdersByConsultant(startDate, endDate);
        }

        public ObjectResult<GetOrdersByProductPrice_Result> GetOrdersByProductPrice(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate,
            decimal? minPrice,
            decimal? maxPrice)
        {
            return _dbContext.GetOrdersByProductPrice(startDate, endDate, minPrice, maxPrice);
        }

        public ObjectResult<GetConsultantsByFrequentlySoldProduct_Result> GetConsultantsByFrequentlySoldProduct(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate,
            int? productCode,
            int? minAmount)
        {
            return _dbContext.GetConsultantsByFrequentlySoldProduct(startDate, endDate, productCode, minAmount);
        }

        public List<ConsultantSales> GetConsultantsSales(DateTimeOffset? startDate,
                                                         DateTimeOffset? endDate)
        {
            if (startDate == null)
            {
                startDate = DateTimeOffset.MinValue;
            }

            if (endDate == null)
            {
                endDate = DateTimeOffset.MaxValue;
            }

            List<Consultant> consultantList = _dbContext.Consultants.ToList();
            List<ConsultantSales> result = new List<ConsultantSales>();

            foreach (Consultant consultant in consultantList)
            {
                result.Add(new ConsultantSales(consultantId: consultant.Id,
                                        consultantName: consultant.Name,
                                        consultantSurname: consultant.Surname,
                                        consultantIdNumber: consultant.IdNumber,
                                        consultantDateOfBirth: consultant.DateOfBirth,
                                        sales: GetConsultantSales(startDate, endDate, consultant.Id),
                                        totalSales: GetConsultantReferralsTotalSales(startDate, endDate, consultant.Id, 0)));
            }

            return result;
        }

        public ObjectResult<GetConsultantsByFrequentlyAndProfitableProducts_Result> GetConsultantsByFrequentlyAndProfitableProducts(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate)
        {
            return _dbContext.GetConsultantsByFrequentlyAndProfitableProducts(startDate, endDate);
        }

        public decimal GetConsultantReferralsTotalSales(DateTimeOffset? startDate, DateTimeOffset? endDate, int id, decimal total)
        {
            total += GetConsultantSales(startDate, endDate, id);
            
            List<Consultant> consultants = _dbContext.Consultants.Where(c => c.ReferrerId == id).ToList();

            foreach (Consultant consultant in consultants)
            {
                decimal subtotal = 0;
                subtotal += GetConsultantReferralsTotalSales(startDate, endDate, consultant.Id, subtotal);
                total += subtotal;
            }

            return total;
        }

        public decimal GetConsultantSales(DateTimeOffset? startDate, DateTimeOffset? endDate, int id)
        {
            GetConsultantSales_Result sales = _dbContext.GetConsultantSales(id, startDate, endDate).FirstOrDefault();
            if (sales == null)
            {
                return 0;
            }

            return sales.TotalSales ?? 0;
        }
    }
}