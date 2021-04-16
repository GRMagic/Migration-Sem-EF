using FluentMigrator;

namespace MigrationSemEF.Migrations
{
    [Migration(2021_04_16_00_00, "Cria registos usando sql puro")]
    public class QuintoMigration : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"insert into estado (sigla, ibge, nome) values ('SC', 42, 'Santa Catarina')", "Criar o estado de Santa Catarina");
        }

        public override void Down()
        {
            Delete.FromTable("estado").Row(new { sigla = "SC" });
        }
    }
}
