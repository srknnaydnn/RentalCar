using Core.DataAccess;
using Core.DataAccess.Entityframework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal :EfEntityRepository<Car,CarRentalContext>, ICarDal
    {
       
    }
}
