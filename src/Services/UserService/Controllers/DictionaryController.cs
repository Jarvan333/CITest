using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Models;

namespace UserService.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class DictionaryController : ControllerBase {
        private static readonly List<DictionaryModel> DictionaryList = new List<DictionaryModel>
        {
            new DictionaryModel()
            {
                Id = 1,
                Name = "客户",
                Children = new List<DictionaryModel>()
                {
                    new DictionaryModel(){Id = 11,Name = "客户1"},
                    new DictionaryModel(){Id = 12,Name = "客户2"}
                }
            },
            new DictionaryModel()
            {
                Id = 2,
                Name = "商品",
                Children = new List<DictionaryModel>()
                {
                    new DictionaryModel(){Id = 21,Name = "商品1"},
                    new DictionaryModel(){Id = 22,Name = "商品2"}
                }
            }
        };
        [HttpGet]
        public ActionResult<ResultModel<List<DictionaryModel>>> Get() {
            return new ResultModel<List<DictionaryModel>> { Data = DictionaryList };
        }

        [HttpGet("{id}")]
        public ActionResult<ResultModel<DictionaryModel>> Get(int id) {
            return new ResultModel<DictionaryModel> { Data = DictionaryList.FirstOrDefault(x => x.Id == id) };
        }

        [HttpPost]
        public ActionResult<ResultModel> Post([FromBody]DictionaryModel model) {
            if (model.Id <= 0 || string.IsNullOrWhiteSpace(model.Name)) return new ResultModel(false, "参数错误");
            if (DictionaryList.Any(x => x.Id == model.Id || x.Name == model.Name)) return new ResultModel(false, "数据已存在");
            DictionaryList.Add(model);
            return new ResultModel();
        }

        [HttpPut("{id}")]
        public ActionResult<ResultModel> Put(int id, [FromBody]DictionaryModel model) {
            var entity = DictionaryList.FirstOrDefault(x => x.Id == id);
            if (entity == null) return new ResultModel(false, "找不到要修改的数据");
            entity.Name = model.Name;
            return new ResultModel();
        }

        [HttpDelete("{id}")]
        public ActionResult<ResultModel> Delete(int id) {
            var entity = DictionaryList.FirstOrDefault(x => x.Id == id);
            if (entity == null) return new ResultModel(false, "找不到要修改的数据");
            DictionaryList.Remove(entity);
            return new ResultModel();
        }
    }
}