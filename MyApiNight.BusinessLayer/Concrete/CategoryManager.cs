using MyApiNight.BusinessLayer.Abstract;
using MyApiNight.DataAccessLayer.Abstract;
using MyApiNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNight.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICatgoryDal _categorDal;

        public CategoryManager(ICatgoryDal categorDal)
        {
            _categorDal = categorDal;
        }

        public void TDelete(int id)
        {
           _categorDal.Delete(id);
        }

        public List<Category> TGetAll()
        {
            return _categorDal.GetAll();
        }

        public Category TGetById(int id)
        {
            return _categorDal.GetById(id);
        }

        public void TInsert(Category entity)
        {
            _categorDal.Insert(entity);
        }

        public void TUpdate(Category entity)
        {
            _categorDal.Update(entity);
        }
    }
}
