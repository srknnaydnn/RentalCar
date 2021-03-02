using Business.Abstract;
using Business.Constans;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManger : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManger(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if (rental.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(true, Message.AddSuccessRental);
            }
            return new SuccessResult(false, Message.AddUnSuccessRental);
        }
    }
}
