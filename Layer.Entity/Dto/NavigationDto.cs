using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class NavigationDto
    {
        public List<NodeDto> compact { get; set; }
        public List<NodeDto> futuristic { get; set; }

        public NavigationDto()
        {
            compact = new List<NodeDto>();
            futuristic = new List<NodeDto>();
        }
    }
}
