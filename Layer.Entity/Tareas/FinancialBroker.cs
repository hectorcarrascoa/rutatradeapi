using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    public partial class FinancialBroker : Audit, IEntity
    {
        public FinancialBroker()
        {
        }
        public long Id { get; set; }
        public long IdBroker { get; set; }
        public long IdFinancial { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Apalanca { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        
    }
}
