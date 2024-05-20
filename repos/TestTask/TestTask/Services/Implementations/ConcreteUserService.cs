using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class ConcreteUserService : IUserService
    {
        private readonly ApplicationDbContext _appContext;

        public ConcreteUserService(ApplicationDbContext appContext)
        {
            _appContext = appContext;
        }

        Task<User> IUserService.GetUser()
        {
            var orders = _appContext.Users.Select(user => user.Orders.Where(order => order.CreatedAt.Year == 2003));
             var sums = orders.Select(orders => orders.Sum(order => order.Price * order.Quantity)).ToList();
            var max = sums.Max();
            var task = new Task<User>(() => _appContext.Users.First(user => user.Orders.Where(order => order.CreatedAt.Year == 2003).Sum(order => order.Price * order.Quantity) == max));
            task.Start();
            return task;
        }

        Task<List<User>> IUserService.GetUsers()
        {
            var task = new Task<List<User>>(() => _appContext.Users.Where(user => user.Orders.Where(order => order.CreatedAt.Year == 2010 && order.Status == Enums.OrderStatus.Paid).Count() > 0).ToList());
            task.Start();
            return task;
        }
    }
}
