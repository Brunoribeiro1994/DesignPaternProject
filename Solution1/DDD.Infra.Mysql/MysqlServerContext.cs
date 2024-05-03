using Microsoft.EntityFrameworkCore;

namespace DDD.Infra.Mysql
{
    public class MysqlServerContext : DbContext
    {
        private string _connectionString = "Server=localhost;Database=alura_curso_v0;Uid=root;Pwd=root;";
        protected override void OnConfiguring(DbContextOptionsBuilder connectionString)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0));
            connectionString.UseMySql(_connectionString, serverVersion);

        }
    }
}
