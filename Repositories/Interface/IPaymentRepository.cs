using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IPaymentRepository
    {
        public List <PaymentMethodResponse> GetPaymentMethods();
        public bool CreatePaymentMethods(string method);

    }
}
