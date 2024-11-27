using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class Broker : Audit, IEntity
    {
        public Broker()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Imagen { get; set; }
        public bool Estado  { get; set; }

    }
}
