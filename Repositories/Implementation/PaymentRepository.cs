using BusinessObjects.DTOs;
using BusinessObjects.Models;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class PaymentRepository : IPaymentRepository
    {   private readonly MilkShopContext _context=new();
        public List<PaymentMethodResponse> GetPaymentMethods()
        { 
            return _context.Payments.Select(x=>new PaymentMethodResponse { Id=x.Id,Method=x.Method}).ToList();
        }

        public bool CreatePaymentMethods(string method)
        {
            _context.Payments.Add(new Payment { Method = method });
            return _context.SaveChanges() >= 1;
        }

       
    }
}
