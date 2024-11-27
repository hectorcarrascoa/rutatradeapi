using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class FinancialAsset : Audit, IEntity
    {
        public FinancialAsset()
        {
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public long IdGrupo { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }

    }
}
