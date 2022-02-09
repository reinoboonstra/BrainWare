using System.Collections.Generic;
using System.Data;
using System.Linq;
using BrainShark.BrainWare.WebApp.Infrastructure.Database;
using BrainShark.BrainWare.WebApp.Models;

namespace BrainShark.BrainWare.WebApp.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDatabase _database;

        public OrderService(IDatabase database)
        {
            _database = database;
        }

        public IEnumerable<Order> GetForCompany(int companyId)
        {
            const string sql1 = "SELECT c.name, o.description, o.order_id FROM company c INNER JOIN [order] o on c.company_id=o.company_id";
            
            var reader1 = _database.ExecuteReader(sql1);
            var values = new List<Order>();
            
            while (reader1.Read())
            {
                var record1 = (IDataRecord) reader1;

                values.Add(new Order
                {
                    CompanyName = record1.GetString(0),
                    Description = record1.GetString(1),
                    OrderId = record1.GetInt32(2),
                    OrderProducts = new List<OrderProduct>()
                });

            }

            reader1.Close();

            const string sql2 = "SELECT op.price, op.order_id, op.product_id, op.quantity, p.name, p.price FROM orderproduct op INNER JOIN product p on op.product_id=p.product_id";

            var reader2 = _database.ExecuteReader(sql2);
            var values2 = new List<OrderProduct>();

            while (reader2.Read())
            {
                var record2 = (IDataRecord)reader2;

                values2.Add(new OrderProduct
                {
                    OrderId = record2.GetInt32(1),
                    ProductId = record2.GetInt32(2),
                    Price = record2.GetDecimal(0),
                    Quantity = record2.GetInt32(3),
                    Product = new Product
                    {
                        Name = record2.GetString(4),
                        Price = record2.GetDecimal(5)
                    }
                });
            }

            reader2.Close();

            foreach (var order in values)
            {
                foreach (var orderProduct in values2.Where(orderProduct => orderProduct.OrderId == order.OrderId))
                {
                    order.OrderProducts.Add(orderProduct);
                    order.OrderTotal += (orderProduct.Price * orderProduct.Quantity);
                }
            }

            return values;
        }
    }
}