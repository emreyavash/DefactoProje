using Business.Interface;
using DataAccess;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductRepository(IGenericRepository<Product> repository)
        {
           _repository = repository;
        }

        public void AddProduct(Product product)
        {
            _repository.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _repository.Delete(product);
        }

        public Product GetProductById(int id)
        {
            var result = _repository.Get(x => x.Id == id);
            return result;
        }

        public List<Product> GetProductsAll()
        {
            var result = _repository.GetAll();
            return result;
        }

        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }
    }
}
