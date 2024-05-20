using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class ConcreteOrderService : IOrderService
    {
        private readonly ApplicationDbContext _appContext;

        public ConcreteOrderService(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }

        Task<Order> IOrderService.GetOrder()
        {
            var task = new Task<Order>(() => _appContext.Orders.First(order => order.CreatedAt == _appContext.Orders.Where(orderInner => orderInner.Quantity > 1).Max(orderInner => orderInner.CreatedAt)));
            task.Start();
            return task;
        }

        Task<List<Order>> IOrderService.GetOrders()
        {
            var orders = _appContext.Orders.Where(order => order.User.Status == Enums.UserStatus.Active).ToList();
            orders.Sort((order1, order2) => order1.CreatedAt.CompareTo(order2.CreatedAt));
            var task = new Task<List<Order>>(() => orders);
            task.Start();
            return task;
        }
    }
}
