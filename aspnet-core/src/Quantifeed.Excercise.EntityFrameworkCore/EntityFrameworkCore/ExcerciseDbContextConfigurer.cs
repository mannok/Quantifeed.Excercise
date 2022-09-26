using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Quantifeed.Excercise.EntityFrameworkCore
{
    public static class ExcerciseDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ExcerciseDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ExcerciseDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
