using NhaHangBuffetPBL3.DataAccess.Data;
using NhaHangBuffetPBL3.Models;
using NhaHangBuffetPBL3.Repository.IRepository;

namespace NhaHangBuffetPBL3.Repository
{
    public class OrdersRepository : Repository<Orders>, IRepositoryOrders
    {
        private NhaHangBuffetContext _db;
        public OrdersRepository(NhaHangBuffetContext db) : base(db)
        {
            _db = db;
        }

        public Orders CheckExpire(List<Orders> obj)
        {
            Orders order = new Orders();
            foreach (var item in obj)
            {
                if (item.IsUsed == 0 && DateTime.Now.Subtract((DateTime)item.SeatingDate).TotalSeconds > 3600)
                {
                    item.IsUsed = -1;
                }
                else if(item.IsUsed == 1)
                {
                    order = item;
                }
            }
            _db.Orders.UpdateRange(obj);
            _db.SaveChanges();
            return order;
        }

        public Orders CheckOrder(string? code)
        {
            var data= _db.Orders.FirstOrDefault(t => t.OrderId == code);
            if(data.IsUsed== 0) data.IsUsed = 1;
            Update(data);
            _db.SaveChanges();
            return data;
        }

        public List<Orders> GetOrdersByTable(int SeatingId)
        {
            return _db.Orders.Where(t => t.SeatingId == SeatingId).ToList();
        }

        public void Update(Orders obj)
        {
            _db.Orders.Update(obj);
        }
    }
}
