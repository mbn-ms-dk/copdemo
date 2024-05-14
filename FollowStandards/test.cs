using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace YourNamespace.Tests
{
    public class PetProxyTests
    {
        [Fact]
        public async Task GetPet_ShouldReturnPet_WhenIdIsValid()
        {
            // Arrange
            var expectedPet = "Expected pet data";
            var id = 123;
            var httpClient = new HttpClient();
            var petProxy = new PetProxy(httpClient);

            // Act
            var actualPet = await petProxy.GetPet(id);

            // Assert
            Assert.Equal(expectedPet, actualPet);
        }
    }
}