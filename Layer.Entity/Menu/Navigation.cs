using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Menu
{
    public class Navigation:IEntity
    {
        public long Id { get; set; }
        public List<Node> compact { get; set; }
        public List<Node> futuristic { get; set; }

        public Navigation()
        {
            compact = new List<Node>();
        }
    }
}
