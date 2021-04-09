using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal: EfEntityRepositoryBase<Customer, Context>,ICustomerDal
    {
        public CustomerDetailDto GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (var context = new Context())
            {
                var result = from customer in  filter is null ? context.Customers: context.Customers.Where(filter)
                             join user in context.Users
                             on customer.UserId equals user.UserId
                             select new CustomerDetailDto
                             {
                                 UserId = user.UserId,
                                 CustomerId = customer.CustomerId,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 CompanyName = customer.CompanyName
                              
                             };
                return result.SingleOrDefault();
            }
        }

    }
}
