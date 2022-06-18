using Bazar_App.Data;
using Bazar_App.Models.DTO;
using Bazar_App.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bazar_App.Models.Services
{
    public class CartService : ICart
    {
        private readonly BazaarDBContext _context;

        public CartService(BazaarDBContext context)
        {
            _context = context;
        }
        public async Task<CartDto> Create(Cart cart)
        {
            _context.Entry(cart).State = EntityState.Added;
            await _context.SaveChangesAsync();
            CartDto newCart = new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId
            };

            return newCart;
        }

        public async Task<List<CartDto>> GetCarts()
        {
            List<CartDto> carts = await _context.Carts.Select(cart => new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId,
                Products = cart.CartProducts.Select(cp => new ProductDto
                {
                    Id = cp.Products.Id,
                    Name = cp.Products.Name,
                    Price = cp.Products.Price,
                    Description = cp.Products.Description,
                    ImgUrl = cp.Products.ImgUrl,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == cp.Products.CategoryId).Name
                }).ToList()
            }).ToListAsync();

            foreach (var item in carts)
            {
                item.TotalCost = ReturnTotalCost(item);
            }

            foreach (var item in carts)
            {
                item.TotalQuantity = GetProductQuantity(item);
            }

            await _context.SaveChangesAsync();

            return carts;
        }

        public async  Task<CartDto> GetCart(int id)
        {
            Cart cartdata = await _context.Carts.FindAsync(id);

            CartDto cart = await _context.Carts.Select(cart => new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId,
                Products = cart.CartProducts.Select(cp => new ProductDto
                {
                    Id = cp.Products.Id,
                    Name = cp.Products.Name,
                    Price = cp.Products.Price,
                    Description = cp.Products.Description,
                    ImgUrl = cp.Products.ImgUrl,
                    CategoryName = _context.Categories.FirstOrDefault(cat => cat.Id == cp.Products.CategoryId).Name
                }).ToList()
            }).FirstOrDefaultAsync(c => c.Id == id);

            cart.TotalCost = ReturnTotalCost(cart);
            cart.TotalQuantity = GetProductQuantity(cart);

            cartdata.TotalCost = cart.TotalCost;
            cartdata.TotalQuantity = cart.TotalQuantity;

            await _context.SaveChangesAsync();

            return cart;
        }

        public async Task<CartDto> GetUserCart(string userId)
        {
            Cart userCart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            if (userCart == null)
            {
                return null;
            }
            CartDto cartDto = await GetCart(userCart.Id);
            return cartDto ;
        }

        public async Task<CartDto> UpdateCart(int id, Cart cart)
        {
            CartDto cartDto = new CartDto
            {
                Id = cart.Id,
                TotalCost = cart.TotalCost,
                TotalQuantity = cart.TotalQuantity,
                UserId = cart.UserId
            };
            _context.Entry(cart).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return cartDto;
        }

        public async Task Delete(int id)
        {
            List<CartProduct> cartProducts = await _context.CartProduct.Where(cp => cp.CartId == id).ToListAsync();
            Product productStock;
            foreach (var item in cartProducts)
            {
                productStock = await _context.Product.FindAsync(item.ProductId);
                productStock.InStock += item.Quantity;
            }
            Cart cart = await _context.Carts.FindAsync(id);
            _context.Entry(cart).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task AddProductToCart(int cartId, int productId)
        {
            var existsCartProduct = _context.CartProduct.Any(cp => cp.ProductId == productId && cp.CartId == cartId);
            Product productStock = await _context.Product.FindAsync(productId);

                if (productStock.InStock > 0)
                {
                    if (existsCartProduct)
                    {
                        CartProduct cartProduct = await _context.CartProduct.Where(x => x.ProductId == productId && x.CartId == cartId).FirstAsync();
                        cartProduct.Quantity += 1;
                        productStock.InStock -= 1;
                        await _context.SaveChangesAsync();
                }
                    else
                    {
                        CartProduct cartProduct = new CartProduct()
                        {
                            ProductId = productId,
                            CartId = cartId,
                            Quantity = 1
                        };

                        productStock.InStock -= 1;
                        _context.Entry(cartProduct).State = EntityState.Added;
                        await _context.SaveChangesAsync();
                }
            }
        }
        public async Task RemoveProductFromCart(int cartId, int productId)
        {
                CartProduct removeProduct = await _context.CartProduct.Where(x => x.ProductId == productId && x.CartId == cartId).FirstAsync();
                Product productStock = await _context.Product.FindAsync(productId);
                if (removeProduct.Quantity > 1)
                {
                    removeProduct.Quantity -= 1;
                    productStock.InStock += 1;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    productStock.InStock += 1;
                    _context.Entry(removeProduct).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                }
        }
        public async Task RemoveCartProduct(int cartId, int productId)
        {
            CartProduct removeProduct = await _context.CartProduct.Where(x => x.ProductId == productId && x.CartId == cartId).FirstAsync();
            Product productStock = await _context.Product.FindAsync(productId);
            productStock.InStock += removeProduct.Quantity;
            _context.Entry(removeProduct).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public int GetProductQuantity(int cartId , int productId)
        {
            int ProductQuantity =  _context.CartProduct.FirstOrDefault(c => c.CartId == cartId && c.ProductId == productId).Quantity;
            return ProductQuantity;
        }

        private double ReturnTotalCost(CartDto cart)
        {
                List<int> QuantityList = _context.CartProduct.Where(cp => cp.CartId == cart.Id).Select(q => q.Quantity).ToList();
                double Total = 0;
                int count = 0;
                foreach (var item in cart.Products)
                {
                    Total += item.Price * QuantityList[0];
                    count++;
                }
                return Total;
        }

        private int GetProductQuantity(CartDto cart)
        {
            int TotalQuantity = 0;

            List<int> cartProduct = _context.CartProduct.Where(cp => cp.CartId == cart.Id).Select(q => q.Quantity).ToList();
            foreach (var item in cartProduct)
            {
                TotalQuantity += item;
            }
            return TotalQuantity;
        }
    }
}
