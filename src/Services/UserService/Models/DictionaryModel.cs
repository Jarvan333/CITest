using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models {
    public class DictionaryModel: BaseModel {
        public string Name { get; set; }
        public List<DictionaryModel> Children { get; set; } = new List<DictionaryModel>();
    }
}
