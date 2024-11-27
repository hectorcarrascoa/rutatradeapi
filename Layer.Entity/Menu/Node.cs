using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity
{
    public class Node: Audit, IEntity
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }

        [ForeignKey("ParentId")]
        public virtual Node Parent { get; set; }
        public virtual ICollection<Node> Children { get; set; } = new List<Node>();
    }
}
