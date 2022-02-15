using CicekSepetiCart.Application.Models;
using CicekSepetiCart.Application.Services;
using CicekSepetiCart.Domain.Entities;
using CicekSepetiCart.Domain.Repositories;
using CicekSepetiCart.Test.TestData;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CicekSepetiCart.Test.TestService
{
    public class CartServiceTest
    {
        private readonly Mock<ICartRepository> _mockCartRepository;

        public CartServiceTest()
        {
            _mockCartRepository = new Mock<ICartRepository>();
        }

        [Theory]
        [ClassData(typeof(AddCartItem_ValidCartItem_ReturnTrue))]
        public async Task AddCartItem_ValidCartItem_ReturnTrue(CartItemModel cartItemModel)
        {
            //arrange
            _mockCartRepository.Setup(x => x.AddAsync(It.IsAny<CartItem>())).ReturnsAsync(new CartItem { });
            var cartService = new CartService(_mockCartRepository.Object);

            //act
            var result = await cartService.AddCartItem(cartItemModel);

            //assert
            Assert.True(result != null);
            _mockCartRepository.Verify(x => x.AddAsync(It.IsAny<CartItem>()), Times.Once);
        }
    }
}
