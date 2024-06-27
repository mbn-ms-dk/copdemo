using NUnit.Framework;
using System.Threading.Tasks;

[TestFixture]
public class StoreProxyTests
{
    private IStoreProxy storeProxy;

    [SetUp]
    public void Setup()
    {
        // Create an instance of the StoreProxy class
        storeProxy = new StoreProxy();
    }
    [Test]
    public async Task GetOrder_ValidId_ReturnsOrder()
    {
        // Arrange
        int orderId = 123;

        // Act
        string order = await storeProxy.GetOrder(orderId);

        // Assert
        Assert.IsNotNull(order);
        Assert.IsNotEmpty(order);
        // Add more specific assertions based on the expected response
    }

    [Test]
    public async Task GetOrder_InvalidId_ReturnsEmptyOrder()
    {
        // Arrange
        int orderId = -1;

        // Act
        string order = await storeProxy.GetOrder(orderId);

        // Assert
        Assert.IsEmpty(order);
        // Add more specific assertions based on the expected response
    }
}