using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Layer.Entity.Dto
{
    public class ConfigDto
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Descripcion { get; set; }
        public long Quantity { get; set; }
        public string BackGround { get; set; } = "images/background/back_1.jpg";
        public string Imagen { get; set; }
        public DateTime? LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }
        public bool Estado { get; set; }
    }
}
