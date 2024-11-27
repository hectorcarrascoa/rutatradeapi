using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity.Dto
{
    public class StatusDto
    {
        public StatusDto()
        {
        }

        public long Id { get; set; }
        public long IdClient { get; set; }
        public string StatusCode { get; set; }
        public string StatusName { get; set; }
        public bool Active { get; set; }
        public DateTime LoadDate { get; set; }
        public string LoadUser { get; set; }
        public DateTime? UpdDate { get; set; }
        public string UpdUser { get; set; }

    }
}
