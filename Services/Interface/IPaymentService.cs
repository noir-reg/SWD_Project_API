
using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPaymentService
    {
        public PaymentResponse ProcessPayment(PaymentRequest paymentRequest);
        public List<PaymentInfo> GetAllPaymentInfo();
        public PaymentInfo GetPaymentInfo(string paymentId);
    }
}
