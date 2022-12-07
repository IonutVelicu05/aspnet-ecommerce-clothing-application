using eClothes.Models;
using Microsoft.EntityFrameworkCore;

namespace eClothes.Data.Cart
{
	public class ShoppingCart
	{
		public AppDbContext _context;

		public string ShoppingCartId { get; set; }

		public List<ShoppingCartItem> ShoppingCartItems { get; set; }

		public ShoppingCart(AppDbContext context)
		{
			_context = context;
		}

		public static ShoppingCart GetShoppingCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<AppDbContext>();
			string cartId = session.GetString("CartId")?? Guid.NewGuid().ToString();

			session.SetString("CartId", cartId);
			return new ShoppingCart(context) { ShoppingCartId = cartId};
		}

		public List<ShoppingCartItem> GetShoppingCartItems()
		{

			return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.
				Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Cloth).ToList());
		}
		public double GetShoppingCartTotal()
		{
			return _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Cloth.Price * n.Amount).Sum();
		}

		public void AddItemToCart(Clothes cloth)
		{
			var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Cloth.Id == cloth.Id && n.ShoppingCartId == ShoppingCartId);
			if(shoppingCartItem == null)
			{
				shoppingCartItem = new ShoppingCartItem() 
				{ 
					ShoppingCartId = ShoppingCartId,
					Cloth = cloth,
					Amount = 1
				};
				_context.ShoppingCartItems.Add(shoppingCartItem);
			}
			else
			{
				shoppingCartItem.Amount++;
			}
			_context.SaveChanges();
		}

		public void RemoveItemFromCart(Clothes cloth)
		{
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Cloth.Id == cloth.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
				if(shoppingCartItem.Amount > 0) { shoppingCartItem.Amount--; }
            }
            else
            {
                _context.ShoppingCartItems.Remove(shoppingCartItem);

            }
            _context.SaveChanges();
        }

		public async Task ClearShoppingCartAsync()
		{
			var items = await _context.ShoppingCartItems.
				Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
			_context.ShoppingCartItems.RemoveRange(items);
			await _context.SaveChangesAsync();
        }


    }
}
