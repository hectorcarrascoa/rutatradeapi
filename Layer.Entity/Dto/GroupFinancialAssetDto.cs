using System;
using System.Collections.Generic;

namespace Layer.Entity.Dto
{
    public partial class GroupFinancialAssetDto 
    {
        public GroupFinancialAssetDto()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagen { get; set; }
        public string BackGround { get; set; } = "images/background/back_1.jpg";
        public bool Estado { get; set; }
        public DateTime? LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }
    }
}
