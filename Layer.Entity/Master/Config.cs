using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    public partial class Config : Audit, IEntity
    {
        public long Id { get; set; }
        public long IdUser { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public long Quantity { get; set; }
        public bool Estado { get; set; }

    }
}
