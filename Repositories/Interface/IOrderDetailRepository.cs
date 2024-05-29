using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interface
{
    public interface IOrderDetailRepository

    {
        public bool CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest);
    }
}
