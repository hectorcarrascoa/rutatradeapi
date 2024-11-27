using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Dto
{
    public class FuseNavigationItemDto
    {
        public string nombre { get; set; }
        public List<NodeDto> childrens { get; set; }
    }
}
