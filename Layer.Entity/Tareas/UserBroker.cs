using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    public partial class UserBroker : Audit, IEntity
    {
        public UserBroker()
        {
        }

        public long Id { get; set; }
        public long IdBroker { get; set; }
        public long IdConfig { get; set; }
        public string Credential1 { get; set; }
        public string Credential2 { get; set; }
        public string Saldo { get; set; }
        public string Imagen { get; set; }
        public string Label { get; set; }
        public bool Estado { get; set; }
    }
}
