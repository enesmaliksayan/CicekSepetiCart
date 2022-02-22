using CicekSepetiCart.Application.Interfaces;
using CicekSepetiCart.Application.Mapper;
using CicekSepetiCart.Application.Models;
using CicekSepetiCart.Application.Models.Enums;
using CicekSepetiCart.Application.Validation;
using CicekSepetiCart.Domain.Entities;
using CicekSepetiCart.Domain.Providers;
using CicekSepetiCart.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CicekSepetiCart.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductProvider _productProvider;
        private readonly IStockProvider _stockProvider;

        public CartService(
            ICartRepository cartRepository, 
            IProductProvider productProvider, 
            IStockProvider stockProvider)
        {
            _cartRepository = cartRepository;
            _productProvider = productProvider;
            _stockProvider = stockProvider;
        }

        public async Task<CartItemModel> AddCartItem(CartItemModel model)
        {
            CartServiceValidation.IsNotValidModel(model);

            var productExists = await _productProvider.CheckIfProductExists(model.ProductId);

            if (!productExists)
                throw new ApplicationException("Product not found.");

            var mapped = ObjectMapper.Mapper.Map<CartItem>(model);
            if (mapped == null)
            {
                throw new ApplicationException($"Entity could not be mapped.");
            }

            try
            {
                var existItem = await _cartRepository.GetSingleAsync
                (q => q.UserId == mapped.UserId &&
                 q.ProductId == mapped.ProductId &&
                 (int)q.Status == (int)CartStatus.New);

                var finalizeQuantity = mapped.Quantity;

                if (existItem != null)
                    finalizeQuantity += existItem.Quantity;

                var isEnoughStock = await _stockProvider.CheckIfEnoughStock(mapped.ProductId, finalizeQuantity);

                if (!isEnoughStock)
                    throw new ApplicationException("There is not enough stock.");

                if (existItem != null)
                {
                    existItem.Quantity = finalizeQuantity;
                    existItem.ModifiedAt = DateTime.Now;
                    await _cartRepository.UpdateAsync(existItem);
                }
                else
                {
                    await _cartRepository.AddAsync(mapped);
                }

                var cartItem = await _cartRepository.GetByIdAsync(mapped.Id);

                return ObjectMapper.Mapper.Map<CartItemModel>(cartItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<CartItemModel>> GetItemsByUserId(string userId)
        {
            try
            {
                if (string.IsNullOrEmpty(userId) || string.IsNullOrWhiteSpace(userId))
                    throw new Exception("UserId is not valid");

                var userItems = await _cartRepository.GetByUserIdAsync(userId);

                var returnList = new List<CartItemModel>();

                userItems.ForEach(q =>
                {
                    returnList.Add(ObjectMapper.Mapper.Map<CartItemModel>(q));
                });

                return returnList;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
