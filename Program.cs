using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MigrationSemEF.Migrations;
using System;

namespace MigrationSemEF
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();
            using var scope = serviceProvider.CreateScope();
            UpdateDatabase(scope.ServiceProvider);
        }

        private static IServiceProvider CreateServices()
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(a => a
                    // Usar com sqlite
                    .AddSQLite()
                    .WithGlobalConnectionString("Data Source=teste.db")
                    // Define o assembly que tem os migrations
                    .ScanIn(typeof(PrimeiroMigration).Assembly).For.Migrations())
                // Logar as atualizações
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
            runner.MigrateDown(0); // desfaz tudo
        }
    }
}
