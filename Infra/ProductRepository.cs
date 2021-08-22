using SalesManagementSystem.db;
using SalesManagementSystem.Domain;
using SalesManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SalesManagementSystem.Infra
{
    public class ProductRepository : IRepository<ProductEntity>
    {
        private readonly SalesManagementSystemEntities db;

        public ProductRepository(SalesManagementSystemEntities dbContext)
        {
            db = dbContext;
        }

        public void Add(ProductEntity productEntity)
        {
            Product product = new Product
            {
                Code = productEntity.Code,
                Name = productEntity.Name,
                Price = productEntity.Price
            };

            db.Products.Add(product);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
        }

        public IEnumerable<ProductEntity> List()
        {
            List<Product> productList = db.Products.ToList();
            List<ProductEntity> result = new List<ProductEntity>();

            foreach (Product product in productList)
            {
                result.Add(new ProductEntity(code: product.Code,
                                             name: product.Name,
                                             price: product.Price));
            }

            return result;
        }

        public ProductEntity GetById(int code)
        {
            Product product = db.Products.FirstOrDefault(p => p.Code == code);

            if (product == null)
            {
                return null;
            }

            return new ProductEntity(code: product.Code,
                                     name: product.Name,
                                     price: product.Price);
        }

        public void Update(ProductEntity productEntity)
        {
            Product product = db.Products.Find(productEntity.Code);
            product.Name = productEntity.Name;
            product.Price = productEntity.Price;
            db.SaveChanges();
        }
    }
}