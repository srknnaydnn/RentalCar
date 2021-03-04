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
               return new SuccessResult(Message.AddSuccess);
          
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "silindi");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"mesaj");
        }

        public IDataResult<List<Car>> GetBrandById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == id),"mesaj");
        }

        public IDataResult<List<Car>> GetColorById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=>p.ColorId==id),"mesaj");
        }

        public IResult Update(Car car)
        {

            _carDal.Update(car);
            return new Result(true, "güncellendi");
        }
    }
}
