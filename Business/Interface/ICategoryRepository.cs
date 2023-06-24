﻿using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetCategoriesAll();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);
    }
}
