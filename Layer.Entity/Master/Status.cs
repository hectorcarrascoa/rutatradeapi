using System;
using System.Collections.Generic;

namespace Layer.Entity
{
    public partial class Status : Audit, IEntity
    {
        public Status()
        {
        }

        public long Id { get; set; }
        public long IdClient { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public bool Active { get; set; }

    }
}
