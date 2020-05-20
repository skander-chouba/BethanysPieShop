using BethanysPieShop.Models.Entities;

namespace BethanysPieShop.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}