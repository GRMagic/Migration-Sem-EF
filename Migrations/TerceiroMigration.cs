using FluentMigrator;

namespace MigrationSemEF.Migrations
{
    [Migration(2021_04_15_21_15, "Criar índices nas colunas de ibge")]
    public class TerceiroMigration : Migration
    {
        public override void Up()
        {
            Create.Index().OnTable("cidade").OnColumn("ibge").Unique();
            Create.Index().OnTable("estado").OnColumn("ibge").Unique();
        }

        public override void Down()
        {
            Delete.Index().OnTable("estado").OnColumn("ibge");
            Delete.Index().OnTable("cidade").OnColumn("ibge");
        }
    }
}
