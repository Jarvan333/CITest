using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Models {
    public class ResultModel {
        public ResultModel(bool success = true, string message = "done") {
            Success = success;
            Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
    public class ResultModel<T>:ResultModel {
        public T Data { get; set; }
    }
}
