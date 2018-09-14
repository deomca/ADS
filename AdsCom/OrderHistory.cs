using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdsCom.Persistence;
using AdsCom.Persistence.Msql;
namespace AdsCom
{
    public class OrderHistory : AbstractDomain
    {
        public int ORDER_ID { get; set; }
        public int ORDER_STATUS { get; set; }
        public int USER_ID { get; set; }
        public int USERALLOCATED { get; set; }
        public DateTime DATE { get; set; }        
        public string ADDITIONALINSTRUCTION { get; set; }
        
       
        public void Save()
        {
            IOrderHistoryPersist persist = new OrderHistoryPersist();
            persist.Save(this);


        }
        public void Load(int OrderhisId)
        {

            IOrderHistoryPersist persist = new OrderHistoryPersist();
            this.Id = OrderhisId;
            persist.Load(this);

        }
        public void Delete(int OrderhisId)
        {
            IOrderHistoryPersist persist = new OrderHistoryPersist();
            this.Id = OrderhisId;
            persist.Delete(this);
        }
        public static IList<OrderHistory> FindAll()
        {
            IList<OrderHistory> o = new List<OrderHistory>();
            IOrderHistoryPersist persist = new OrderHistoryPersist();
            return o = persist.FindAll();

        }
        public static IList<OrderHistory> LoadByOrderId(int OrderId)
        {
            IList<OrderHistory> u = new List<OrderHistory>();
            IOrderHistoryPersist persist = new OrderHistoryPersist();
            return u = persist.LoadByOrderId(OrderId);

        }
    }
}
