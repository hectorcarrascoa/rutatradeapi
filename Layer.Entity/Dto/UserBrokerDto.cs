using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class UserBrokerDto
    {
        public long Id { get; set; }
        public long IdBroker { get; set; }
        public long IdConfig { get; set; }
        public string Credential1 { get; set; }
        public string Credential2 { get; set; }
        public string Saldo { get; set; }
        public string Imagen { get; set; }
        public string Label { get; set; }
        public bool Estado { get; set; }
        public string BackGround { get; set; } = "images/background/back_1.jpg";
        public DateTime? LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }
    }
}
