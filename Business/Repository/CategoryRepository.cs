using Business.Interface;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryRepository(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public void AddCategory(Category category)
        {
            _repository.Add(category);
        }

        public void DeleteCategory(Category category)
        {
            _repository.Delete(category);
        }

        public List<Category> GetCategoriesAll()
        {
            var result = _repository.GetAll();
            return result;
        }

        public Category GetCategoryById(int id)
        {
            var result = _repository.Get(x=>x.Id ==id);
            return result;
        }

        public void UpdateCategory(Category category)
        {
            _repository.Update(category);
        }
    }
}
