using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult Add(Car car)
        {
            

               _carDal.Add(car);
               return new SuccessResult(true, Message.AddSuccess);
          
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "silindi");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),true,"mesaj");
        }

        public IDataResult<List<Car>> GetBrandById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),true,"mesaj");
        }

        public IDataResult<List<Car>> GetColorById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId==id),true,"mesaj");
        }

        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new Result(true, "güncellendi");
        }
    }
}
