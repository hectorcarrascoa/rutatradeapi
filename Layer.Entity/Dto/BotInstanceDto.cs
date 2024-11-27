using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class BotInstanceDto
    {
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
        public string BackGround { get; set; } = "images/background/back_1.jpg";
        public DateTime? LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }
    }
}
