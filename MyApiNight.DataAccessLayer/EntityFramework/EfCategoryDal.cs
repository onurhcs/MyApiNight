﻿using MyApiNight.DataAccessLayer.Abstract;
using MyApiNight.DataAccessLayer.Context;
using MyApiNight.DataAccessLayer.Repositories;
using MyApiNight.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApiNight.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICatgoryDal
    {
        public EfCategoryDal(ApiContext context) : base(context)
        {
        }
    }
}
