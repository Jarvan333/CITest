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
    public class MenuController : ControllerBase {
        private static readonly List<MenuModel> DictionaryList = new List<MenuModel>
        {
            new MenuModel()
            {
                Id = 1,
                Title = "主页",
                Icon = "home",
                Children = new List<MenuModel>()
                {
                    new MenuModel(){Id = 11,Title = "欢迎",Url = "home/index"},
                    new MenuModel(){Id = 12,Title = "字典",Url = "home/dictionary"},
                    new MenuModel(){Id = 13,Title = "菜单",Url = "home/menu"},
                }
            },
            new MenuModel()
            {
                Id = 1,
                Title = "用户",
                Icon = "user",
                Children = new List<MenuModel>()
                {
                    new MenuModel(){Id = 11,Title = "用户列表",Url = "user/index"},
                    new MenuModel(){Id = 12,Title = "权限",Url = "home/permission"},
                    new MenuModel(){Id = 13,Title = "角色",Url = "home/role"},
                }
            }
        };
        [HttpGet]
        public ActionResult<ResultModel<List<MenuModel>>> Get() {
            return new ResultModel<List<MenuModel>> { Data = DictionaryList };
        }

        [HttpGet("{id}")]
        public ActionResult<ResultModel<MenuModel>> Get(int id) {
            return new ResultModel<MenuModel> { Data = DictionaryList.FirstOrDefault(x => x.Id == id) };
        }

        [HttpPost]
        public ActionResult<ResultModel> Post([FromBody]MenuModel model) {
            if (model.Id <= 0 || string.IsNullOrWhiteSpace(model.Title)) return new ResultModel(false, "参数错误");
            if (DictionaryList.Any(x => x.Id == model.Id || x.Title == model.Title)) return new ResultModel(false, "数据已存在");
            DictionaryList.Add(model);
            return new ResultModel();
        }

        [HttpPut("{id}")]
        public ActionResult<ResultModel> Put(int id, [FromBody]MenuModel model) {
            var entity = DictionaryList.FirstOrDefault(x => x.Id == id);
            if (entity == null) return new ResultModel(false, "找不到要修改的数据");
            entity.Title = model.Title;
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