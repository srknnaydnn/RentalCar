using Business.Abstract;
using Business.Constans;
using Core.Aspect.NewFolder.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(ValidationTool))]
        public IResult Add(Customer customer)
        {

            if(customer.UserId==null && customer.CompanyName == null)
            {
                return new ErrorResult("Hata");
            }
            _customerDal.Add(customer);

            return new SuccessResult(Message.CustomerAddSuccess);
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Message.CustomerDeleteSuccess);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Message.CustomersListSuccess);
        }

        public IDataResult<Customer> GetByID(int id)
        {
            return new ErrorDataResult<Customer>(_customerDal.Get(p=>p.CustomerId==id), Message.CustomerListUnSuccess);
        }
    }
}
