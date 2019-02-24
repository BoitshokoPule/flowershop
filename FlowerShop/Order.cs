using System;
using System.Collections.Generic;
using System.Text;

namespace FlowerShop
{
    public class Order : IOrder, IIdentified
    {
        private List<Flower> flowers;
        private bool isDelivered = false;
        public int Id { get; }

        // should apply a 20% mark-up to each flower.
        public double Price {
           
            get {
                this.flowers = new List<Flower>();
                double totalCost = 0;
                int i = 0;
                while (i < flowers.Count)
                {
                    totalCost += flowers[i].Cost + flowers[i].Cost * 0.2;
                    //cost of all the flowers pilus the 20% markup
                    i++;
                }
                return totalCost;
            }
        }

        public double Profit {
            get {
                return 0;
            }
        }

        public IReadOnlyList<IFlower> Ordered {
            get {
                return flowers.AsReadOnly();
            }
        }

        public IClient Client { get; private set; }

        public Order(IOrderDAO dao, IClient client)
        {
            Id = dao.AddOrder(client);
        }

        // used when we already have an order with an Id.
        public Order(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            this.flowers = new List<Flower>();
            this.isDelivered = isDelivered;
            Client = client;
            Id = dao.AddOrder(client);
        }

        public void AddFlowers(IFlower flower, int n)
        {
            throw new NotImplementedException();
        }

        public void Deliver(IOrderDAO dao, IClient client, bool isDelivered = false)
        {
            Order ord = new Order(dao, client);
            dao.SetDelivered(ord);
        }

    }
}
