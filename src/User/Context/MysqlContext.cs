using Microsoft.EntityFrameworkCore;

namespace Seguradora.src.User.Context {
    public class MysqlContext : DbContext {
        public DbSet<User> Users { get; set; }

        public MysqlContext () {}

        public MysqlContext (DbContextOptions<MysqlContext> options) : base (options) {}
    }

}