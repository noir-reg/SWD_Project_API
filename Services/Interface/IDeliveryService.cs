using BusinessObjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IDeliveryService
    {
        public bool CreateDelivery(int orderId, int deliveryManId);
        public bool DeleteDelivery(int deliveryId);
        public List<DeliveryOrder> GetDeliveryOrdersByDeliveryManId(int deliveryManId);
        public List<DeliveryOrder> GetAllDeliveryOrders();
        public List<DeliveryOrder> GetDeliveredOrdersByDeliveryManId(int deliveryManId);
    }
}
