using System;
using System.Collections.Generic;

namespace Layer.Entity.Dto
{
    public partial class FinancialBrokerDto
    {
        public FinancialBrokerDto()
        {
        }

        public long Id { get; set; }
        public long IdBroker { get; set; }
        public long IdFinancial { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int Apalanca { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        public string BackGround { get; set; } = "images/background/back_1.jpg";
        public DateTime? LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }

    }

}

