using Business.Abstract;
using Business.Constans;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class CarImagesManger : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManger(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IResult Add(CarImages carImages)
        {
            IResult result = BusinessRules.Run(CheckIfCarImagesLimited(carImages.CarId));

            if (result != null)
            {
                return result;
            }
            if (CheckIfCarImagesLimited(carImages.CarId).Success)
            {

                _carImagesDal.Add(carImages);
                return new SuccessResult(true, Message.AddSuccessCarImages);
            }
            return new ErrorResult(false, "Araba Resmi Eklenmedi");
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(), true, "Resimler Listelendi");
        }

        public IResult Delete(CarImages carImages)
        {
            _carImagesDal.Delete(carImages);
            return new SuccessResult(true, "resim silindi");
        }

        public IResult Update(CarImages carImages)
        {
            _carImagesDal.Update(carImages);
            return new SuccessResult(true, "resim güncellendi");
        }

        public IDataResult<CarImages> GetById(int id)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(p => p.CarId == id), true, "listelendi");
        }
        private IResult CheckIfCarImagesLimited(int carId)
        {
            var result = _carImagesDal.GetAll(p => p.CarId == carId).Count;
            if (result > 5)
            {
                return new ErrorResult(false, Message.CarImagesLimited);
            }
            return new SuccessResult();
        }

        private IDataResult<CarImages> CreateFile(CarImages carImages)
        {
            var uniqueFileName = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".jpeg";
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\images");
            string carImagePath = Path.Combine(carImages.ImagePath);
            string result = $"{path}\\{uniqueFileName}";

            try
            {
                File.Move(carImagePath,path+"\\"+uniqueFileName);
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<CarImages>(false,exception.Message);
            }

            return new SuccessDataResult<CarImages>(new CarImages
            {
                Id = carImages.Id,
                CarId = carImages.CarId,
                ImagePath = result,
                Date = DateTime.Now,
            }, true);

        }
        private IDataResult<CarImages> UpdateFile(CarImages carImages)
        {
            var uniqueFileName = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Year + "_" + DateTime.Now.Month + "_" + DateTime.Now.Day + ".jpeg";
            string path = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).FullName + @"\images");
            string carImagePath = Path.Combine(carImages.ImagePath);
            string result = $"{path}\\{uniqueFileName}";
            File.Copy(carImages.ImagePath, path + "\\" + uniqueFileName);
            File.Delete(carImages.ImagePath);
            return new SuccessDataResult<CarImages>(new CarImages
            {
                Id = carImages.Id,
                CarId = carImages.CarId,
                ImagePath = result,
                Date = DateTime.Now,
            }, true);

        }

    }
}
