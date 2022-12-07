using eClothes.Data.Static;
using eClothes.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace eClothes.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Cloth).Include(n=> n.User).ToListAsync();
            if(userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }
            return orders;
        }

        public async Task<Order> GetOrderByUserIdAsync(int orderId)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(n => n.Id == orderId);
            //var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Cloth).Include(n => n.User);
            return order;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress, string address
            , string city, string county, string zipcode, string phoneNumber)
        {
            var totalPrice = 0;
            foreach (var item in items)
            {
                totalPrice += item.Cloth.Price;
            }
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
                Address = address,
                City = city,
                County = county,
                Zipcode = zipcode,
                PhoneNumber = phoneNumber,
                Total = totalPrice.ToString(),
                OrderConfirmed = "False"
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach(var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ClothId = item.Cloth.Id,
                    OrderId = order.Id,
                    Price = item.Cloth.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var existingOrders = _context.Orders.Where(n => n.Id == id).ToList();
            _context.Orders.RemoveRange(existingOrders);
            await _context.SaveChangesAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
            return order;
        }
        public async Task UpdateOrderAsync(Order order)
        {
            var orderFound = await _context.Orders.FirstOrDefaultAsync(o => o.Id == order.Id);
            if(orderFound != null)
            {
                orderFound.Address = order.Address;
                orderFound.Zipcode = order.Zipcode;
                orderFound.City = order.City;
                orderFound.County = order.County;
                orderFound.Email = order.Email;
                orderFound.PhoneNumber = order.PhoneNumber;
                orderFound.OrderItems = order.OrderItems;
                orderFound.OrderConfirmed = order.OrderConfirmed;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetConfirmedOrdersAsync()
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Cloth).Include(n => n.User).ToListAsync();
            orders = orders.Where(n => n.OrderConfirmed == "True").ToList();
            return orders;
        }

        public async Task<List<Order>> GetUnConfirmedOrdersAsync()
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Cloth).Include(n => n.User).ToListAsync();
            orders = orders.Where(n => n.OrderConfirmed == "False").ToList();
            return orders;
        }
    }
}
