using NhaHangBuffetPBL3.Models;

namespace NhaHangBuffetPBL3.Repository.IRepository
{
    public interface IRepositoryOrders : IRepository<Orders>
    {
        void Update(Orders obj);
        Orders CheckOrder(string? code);
        List<Orders> GetOrdersByTable(int SeatingId);
        Orders CheckExpire(List<Orders> obj);
    }
}
