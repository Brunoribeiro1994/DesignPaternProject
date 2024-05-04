using DDD.Infra.Mysql.Model;
using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Mysql
{
    public class MysqlServerContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        private string _connectionString = "Server=localhost;Database=sistema_vendas_v1;Uid=root;Pwd=root;";
        protected override void OnConfiguring(DbContextOptionsBuilder connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0));
            connectionString.UseMySql(_connectionString, serverVersion);

        }
    }
}
