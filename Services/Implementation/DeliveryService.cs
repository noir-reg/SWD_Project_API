using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DTOs;
using Repositories.Interface;
using Services.Interface;

namespace Services.Implementation
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _repository;
        public DeliveryService(IDeliveryRepository repository)
        {
            _repository = repository;
        }
        public bool CreateDelivery(int orderId, int deliveryManId)
        {
           return _repository.CreateDelivery(orderId, deliveryManId);
        }

        public bool DeleteDelivery(int deliveryId)
        {
           return _repository.DeleteDelivery(deliveryId);
        }

        public List<DeliveryOrder> GetAllDeliveryOrders()
        {
          return  _repository.GetAllDeliveryOrders();
        }

        public List<DeliveryOrder> GetDeliveredOrdersByDeliveryManId(int deliveryManId)
        {
            return _repository.GetDeliveredOrdersByDeliveryManId(deliveryManId);
        }

        public List<DeliveryOrder> GetDeliveryOrdersByDeliveryManId(int deliveryManId)
        {
           return _repository.GetDeliveryOrdersByDeliveryManId(deliveryManId);
        }
    }
}
