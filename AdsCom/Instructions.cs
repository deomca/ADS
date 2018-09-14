using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdsCom.Persistence;
using AdsCom.Persistence.Msql;
namespace AdsCom
{
    public class Instructions:AbstractDomain
    {

        public string ADDITIONALINSTRUCTION { get; set; }
        public int ORDER_ID { get; set; }
        public int USER_ID { get; set; }
        public DateTime Date { get; set; }

       

        public void Save()
        {
            IInstructionsPersist persist = new InstructionsPersist();
            persist.Save(this);


        }
        public void Load(int InstructionsId)
        {

            IInstructionsPersist persist = new InstructionsPersist();
            this.Id = InstructionsId;
            persist.Load(this);

        }
        public void Delete(int InstructionsId)
        {
            IInstructionsPersist persist = new InstructionsPersist();
            this.Id = InstructionsId;
            persist.Delete(this);
        }
        public static IList<Instructions> FindAll()
        {
            IList<Instructions> o = new List<Instructions>();
            IInstructionsPersist persist = new InstructionsPersist();
            return o = persist.FindAll();

        }
        public static IList<Instructions> LoadByOrderId(int OrderId)
        {
            IList<Instructions> o = new List<Instructions>();
            IInstructionsPersist persist = new InstructionsPersist();
            return o = persist.LoadByOrderId(OrderId);
        }
        
    }
}
