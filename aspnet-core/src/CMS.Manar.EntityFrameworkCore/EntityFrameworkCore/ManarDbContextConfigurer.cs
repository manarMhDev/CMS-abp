using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CMS.Manar.EntityFrameworkCore
{
    public static class ManarDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ManarDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ManarDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
