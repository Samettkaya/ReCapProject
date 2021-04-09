using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

  

        public IResult Add(Payment payment)
        {
            payment.PaymentDate = DateTime.Now;
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentSuccessful);
        }
    }
}
