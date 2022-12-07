using eClothes.Data.Cart;
using eClothes.Data.Services;
using eClothes.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eClothes.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IClothesService _service;
		private readonly ShoppingCart _shoppingCart;
		private readonly IOrdersService _ordersService;

		public OrdersController(IClothesService service, ShoppingCart shoppingCart, IOrdersService ordersService)
		{
			_service = service;
			_shoppingCart = shoppingCart;
			_ordersService = ordersService;
		}

		public async Task<IActionResult> Index()
		{
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string userRole = User.FindFirstValue(ClaimTypes.Role);
			var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
			return View(orders);
		}
		public async Task<IActionResult> ShowConfirmed()
		{
			var orders = await _ordersService.GetConfirmedOrdersAsync();
			return View("Index", orders);
		}
        public async Task<IActionResult> ShowUnconfirmed()
        {
            var orders = await _ordersService.GetUnConfirmedOrdersAsync();
            return View("Index", orders);
        }
        public async Task<IActionResult> OrderDetails(int id)
		{
			var order = await _ordersService.GetOrderByUserIdAsync(id);
			return View(order);
		}
		public IActionResult ShoppingCart()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			_shoppingCart.ShoppingCartItems = items;
			var response = new ShoppingCartVM()
			{
				ShoppingCart = _shoppingCart,
				ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
			};
			if(response.ShoppingCart.ShoppingCartItems.Count < 1)
			{
				_shoppingCart.ClearShoppingCartAsync();
			}
			return View(response);
		}

		public async Task<IActionResult> AddToShoppingCart(int id)
		{
			var cloth = await _service.GetClothByIdAsync(id);
			if(cloth != null)
			{
				_shoppingCart.AddItemToCart(cloth);
			}
			return RedirectToAction(nameof(ShoppingCart));
		}
        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var cloth = await _service.GetClothByIdAsync(id);
            if (cloth != null)
            {
                _shoppingCart.RemoveItemFromCart(cloth);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }

		public async Task<IActionResult> CompleteOrder(string address, string county, string city, string zipcode, string phoneNumber)
		{
			var items = _shoppingCart.GetShoppingCartItems();
			string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
			string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);
			await _ordersService.StoreOrderAsync(items, userId, userEmailAddress, address, city, county, zipcode, phoneNumber);
			await _shoppingCart.ClearShoppingCartAsync();
			return View("OrderComplete");
		}
        //get. Discounts/ Edit
        public async Task<IActionResult> ConfirmOrder(int id)
        {
            var order = await _ordersService.GetOrderByIdAsync(id);
            if (order == null) return View("NotFound");
            return View(order);
        }

        //post
        [HttpPost, ActionName("ConfirmOrder")]
        public async Task<IActionResult> OrderConfirmed(int id)
        {
            var order = await _ordersService.GetOrderByIdAsync(id);
			order.OrderConfirmed = "True";
			await _ordersService.UpdateOrderAsync(order);
            return RedirectToAction(nameof(Index));
        }
    }
}
