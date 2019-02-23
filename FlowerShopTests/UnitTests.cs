using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var orderdao = Substitute.For<IOrderDAO>();
            var client = Substitute.For<IClient>();
            var isDiliver = Substitute.For<bool>();
        }

        [Test]
        public void Test1()
        {
            //ARRANGE
            var order = new Order(orderdao, client, isDiliver);
            //ACT
            order.Deliver();
            //ASSERT
            orderdao.Received().SetDelivered(orderdao);
        }
    }
}