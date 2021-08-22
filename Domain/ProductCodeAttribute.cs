using SalesManagementSystem.db;
using SalesManagementSystem.Infra;
using SalesManagementSystem.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Domain
{
    public class ProductCodeAttribute : ValidationAttribute
    {
        private readonly IRepository<ProductEntity> productRepository;

        public ProductCodeAttribute()
        {
            productRepository = new ProductRepository(new SalesManagementSystemEntities());
        }

        public override bool IsValid(object value)
        {
            int productCode = Convert.ToInt32(value);
            ProductEntity product = productRepository.GetById(productCode);

            if (product == null)
            {
                return false;
            }

            return true;
        }
    }
}