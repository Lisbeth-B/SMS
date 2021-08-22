using SalesManagementSystem.db;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

namespace SalesManagementSystem.Domain
{
    public interface IOrderService
    {
        ObjectResult<GetOrdersByConsultant_Result> GetOrdersByConsultant(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate);

        ObjectResult<GetOrdersByProductPrice_Result> GetOrdersByProductPrice(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate,
            decimal? minPrice,
            decimal? maxPrice);

        ObjectResult<GetConsultantsByFrequentlySoldProduct_Result> GetConsultantsByFrequentlySoldProduct(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate,
            int? productCode,
            int? minAmount);

        List<ConsultantSales> GetConsultantsSales(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate);

        ObjectResult<GetConsultantsByFrequentlyAndProfitableProducts_Result> GetConsultantsByFrequentlyAndProfitableProducts(
            DateTimeOffset? startDate,
            DateTimeOffset? endDate);
    }
}
