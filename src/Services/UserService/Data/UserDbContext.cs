using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserService.Data.Entity;

namespace UserService.Data {
    public class UserDbContext:DbContext {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="options">数据库上下文配置</param>
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserEntity> User { get; set; }
    }
}
