﻿using Core.DataAccess.Entityframework;
using Core.Entities;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepository<User,CarRentalContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context=new CarRentalContext())
            {
                var result = from opertaionClaim in context.OperationClaims 
                             join userOperationClaim in context.UserOperationClaims
                             on opertaionClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = opertaionClaim.Id, Name = opertaionClaim.Name };


                return result.ToList();
            }
        }

    }
}