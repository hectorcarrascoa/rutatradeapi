using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class Bot : Audit, IEntity
    {
        public Bot()
        {
        }

        public long Id { get; set; }
        public long IdUser { get; set; }
        public long IdFinancialAsset { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Temp { get; set; }
        public bool Estado { get; set; }
        public string Imagen { get; set; }
        //public string Background { get; set; }

    }
}
