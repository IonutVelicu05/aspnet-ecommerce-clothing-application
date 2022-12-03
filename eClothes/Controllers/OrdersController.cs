using eClothes.Data.Cart;
using eClothes.Data.Services;
using eClothes.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
			string userId = "";
			var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
			return View(orders);
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

		public async Task<IActionResult> CompleteOrder()
		{
			var items = _shoppingCart.GetShoppingCartItems();
			string userId = "";
			string userEmailAddress = "";
			await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
			await _shoppingCart.ClearShoppingCartAsync();
			return View("OrderComplete");
		}

    }
}
