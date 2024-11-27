using System;
using System.Collections.Generic;
using System.Text;

namespace Layer.Entity.Dto
{
    public  class SubMenuDto
    {
        public SubMenuDto()
        {
            Children = new List<SubMenuDto>();
        }

        public long Id { get; set; }
        public int ParentId { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Icon { get; set; }
        public string Link { get; set; }
        public List<SubMenuDto> Children { get; set; }
    }
}
