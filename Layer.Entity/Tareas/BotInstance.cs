using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class BotInstance : Audit, IEntity
    {
        public BotInstance()
        {
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public long IdBot { get; set; }
        public long? IdBroker { get; set; }
        public long IdConfig { get; set; }
        public long Quantity { get; set; }
        public long TakeProfir { get; set; }
        public long StopLoss { get; set; }
        public string Reason { get; set; }
        public int Apalanca { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        public string Name { get; set; }

    }
}
