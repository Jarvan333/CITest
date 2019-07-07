using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models {
    public class MenuModel : BaseModel {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public List<MenuModel> Children { get; set; } = new List<MenuModel>();
    }
}
