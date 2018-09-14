using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdsCom.Persistence;
using AdsCom.Persistence.Msql;

namespace AdsCom
{
    public class Order : AbstractDomain
    {
        public int ORDER_ID { get; set; }
        public int EVENT_ID { get; set; }
        public string GRAPHER_ID { get; set; }
        public int STATUS_ID { get; set; }
        public int USER_ID { get; set; }
        public DateTime ORDER_DATE { get; set; }
        public DateTime ADS_DATE { get; set; }
        public string FOLDER_NAME { get; set; }
        public int PAGES { get; set; }
        public int ALBUM_TYPE { get; set; }
        public int ALBUM_STYLE { get; set; }
        public int ALBUM_SIZE { get; set; }
        public int ORIGINAL_ALBUM_ID { get; set; }
        public int ALBUM_ID { get; set; }
        public int IMAGES { get; set; }
        public string ALBUM_NAME { get; set; }
        public int ORDER_STATUS { get; set; }
        public int ALBUM_RATING { get; set; }
        public string COMMENTS { get; set; }
        public string SPECIAL_INSTRUCTIONS { get; set; }
        public int ACTION { get; set; }
        public string GENERALGUIDELINES { get; set; }
        public int INSTRUCTION_ID { get; set; }
        public string PRODUCT_NAME { get; set; }
        public int PRIORITY { get; set; }
        public int RELEASE_STATUS { get; set; }
        public string IMAGE_LIST { get; set; }
        public string REDESIGN { get; set; }
      

        public void Save()
        {
           IOrderPersist  persist = new OrderPersist();
            persist.Save(this);


        }
        public void Load(int AdsId)
        {

            IOrderPersist persist = new OrderPersist();
            this.Id = AdsId;
            persist.Load(this);

        }
        public void Delete(int AdsId)
        {
            IOrderPersist persist = new OrderPersist();
            this.Id = AdsId;
            persist.Delete(this);
        }
        public static IList<Order> FindAll()
        {
            IList<Order> o = new List<Order>();
            IOrderPersist persist = new OrderPersist();
            return o = persist.FindAll();

        }
        public IList<Order> LoadByOrderDate(DateTime OrderDate, int UserId)
        {
            IList<Order> o = new List<Order>();
            IOrderPersist persist = new OrderPersist();
            return o = persist.LoadByOrderDate(OrderDate, UserId);

        }
        public static IList<Order> LoadByStatusId(int StatusId)
        {
            IList<Order> o = new List<Order>();
            IOrderPersist persist = new OrderPersist();
            return o = persist.LoadByStatusId(StatusId);

        }
        public IList<Order> LoadByOrderId(int OrderId)
        {
            IList<Order> o = new List<Order>();
            IOrderPersist persist = new OrderPersist();
            return o = persist.LoadByOrderId(OrderId);
        }
        public IList<Order> LoadByUserId(int UserId)
        {
            IList<Order> o = new List<Order>();
            IOrderPersist persist = new OrderPersist();
            return o = persist.LoadByUserId(UserId);
        }
        public static IList<Order> LoadByStatusIdandUserId(string StatusId, string UserId)
        {
            IList<Order> o = new List<Order>();
            IOrderPersist persist = new OrderPersist();           
            return o = persist.LoadByStatusIdandUserId(StatusId, UserId);
            
        }



    }
}
