using NUnit.Framework;
using FlowerShop;
using NSubstitute;

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
            var flowr= Substitute.For<Flower>();
            //
            
        }

        [Test]
        public void Test1()
        {
            //ARRANGE
            var order = new Order(orderdao, client, isDiliver);
            //ACT
            order.Deliver();
            //ASSERT
            orderdao.Received().SetDelivered(order);

        }
        [Test] //Checking Orders Price

        public void Test2()
        {
            //ARRANGE
            var order = new Order(orderdao, client, isDiliver);
            //ACT
            double pr= order.Price();
            //ASSERT
            Assert.AreEqual(pr, flowr.Cost);
        }
    }
}