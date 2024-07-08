using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects.DTOs;

namespace Repositories.Interface
{
    public interface IDeliveryRepository
    {
        public bool CreateDelivery(int orderId, int deliveryManId);
        public bool DeleteDelivery(int deliveryId);
        public List<DeliveryOrder> GetDeliveredOrdersByDeliveryManId(int deliveryManId);
        public List<DeliveryOrder> GetDeliveryOrdersByDeliveryManId(int deliveryManId);
        public List<DeliveryOrder> GetAllDeliveryOrders();
    }
}
