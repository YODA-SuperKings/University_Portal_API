using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface IPaymentService
    {
        List<Payment> GetPayment();
        string CreatePayment(Payment _Payment);
    }
}
