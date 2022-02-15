using AutoMapper;
using CicekSepetiCart.API.ViewModels;
using CicekSepetiCart.Application.Interfaces;
using CicekSepetiCart.Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CicekSepetiCart.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;
        public CartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<CartItemModel>> AddItemToCart([FromBody] CartItemViewModel cartItemViewModel)
        {
            try
            {
                var mapped = _mapper.Map<CartItemModel>(cartItemViewModel);
                if (mapped == null)
                    throw new Exception("Mapping operation had an error");

                var resItem = await _cartService.AddCartItem(mapped);

                return Ok(resItem);
            }
            catch (Exception e)
            {
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<CartItemModel>>> GetItemsByUserId([FromQuery] string userId)
        {
            try
            {
                var resItems = await _cartService.GetItemsByUserId(userId);

                return Ok(resItems);
            }
            catch (Exception e)
            {
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }
    }
}
