using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Web.Models;
using Shop.Web.Models.Data;
using Shop.Web.Models.Repository;
using Shop.Web.ViewModels;

namespace Shop.Web.Controllers.Api
{
 
    public class CartController : Controller
    {
        private IBookstoreRepository _repository;
        private ILogger<CartController> _logger;

        public CartController(IBookstoreRepository repository, ILogger<CartController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("api/cart")]
        public IActionResult GetAllCartItems()
        {
            try
            {
                var items = _repository.GetAllCartItems();
            return Ok(Mapper.Map<IEnumerable<CartItemViewModel>>(items));
            }
            
            catch (Exception ex)
            {
                _logger.LogError("Failed to load cart items: {0}", ex);
            }
            return BadRequest("Failed to load cart items");
        }


        [HttpGet("api/cart/{cartItemId}")]
        public IActionResult GetCartItemById(int cartItemId)
        {
            try
            {
                var cartItem = _repository.GetCartItemById(cartItemId);
                return Ok(Mapper.Map<CartItemViewModel>(cartItem));
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to load cart item : {0}", ex);
            }
            return BadRequest("Failed to load cart item");
        }


        [HttpPost("api/cart")]
        public async Task<IActionResult> Post([FromBody] CartItemViewModel cartItem)
        {
            try
            {
                var newCartItem = Mapper.Map<CartItem>(cartItem);
                _repository.AddCartItem(newCartItem);


                if (await _repository.SaveChangesAsync())
                {
                    return Created($"api/cart/{cartItem.CartItemId}", Mapper.Map<CartItemViewModel>(newCartItem));
                }
            }

            catch (Exception ex)
            {
                _logger.LogError("Failed to save cart item {0}", ex);
            }
            return BadRequest("Failed to save cart item");
        }
    }
}
