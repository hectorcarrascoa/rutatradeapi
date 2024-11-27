using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public  class NodeDto
    {
        public long Id { get; set; }
        
        public string Title { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }

        public virtual ICollection<NodeDto> Children { get; set; } = new List<NodeDto>();
    }
}
