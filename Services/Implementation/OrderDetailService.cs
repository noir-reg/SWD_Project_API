using BusinessObjects.DTOs;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class OrderDetailService : IOrderDetailService
    {  private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }
        public bool CreateOrderDetail(CreateOrderDetailRequest createOrderDetailRequest)
        {
          return _orderDetailRepository.CreateOrderDetail(createOrderDetailRequest);
        }
    }
}
