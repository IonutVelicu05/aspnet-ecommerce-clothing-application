using eClothes.Models;

namespace eClothes.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress, string address
            , string city, string county, string zipcode, string phoneNumber);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole);
        Task<Order> GetOrderByUserIdAsync(int orderId);
        Task DeleteOrderAsync(int id);
        Task<Order> GetOrderByIdAsync(int id);
        Task UpdateOrderAsync(Order order);
        Task<List<Order>> GetConfirmedOrdersAsync();
        Task<List<Order>> GetUnConfirmedOrdersAsync();
    }
}
