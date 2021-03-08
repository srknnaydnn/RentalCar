using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constans;
using Business.DependencyResolvers.FluentValidation;
using Core.Aspect.Autofac.Caching;
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
        [CacheRemoveAspect("ICustomerService.Get")]
        [SecuredOperation("admin,customer.add")]
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

            if(customer.UserId==null && customer.CompanyName == null)
            {
                return new ErrorResult("Hata");
            }
            _customerDal.Add(customer);

            return new SuccessResult(Message.CustomerAddSuccess);
        }
        [SecuredOperation("moderator")]

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Message.CustomerDeleteSuccess);
        }
        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(),Message.CustomersListSuccess);
        }

        [CacheAspect]
        public IDataResult<Customer> GetByID(int id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(p=>p.CustomerId==id), Message.CustomerListSuccess);
        }
    }
}
