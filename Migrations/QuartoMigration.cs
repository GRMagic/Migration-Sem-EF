using FluentMigrator;

namespace MigrationSemEF.Migrations
{
    [Migration(2021_04_15_23_45, "Adiciona a coluna com a sigla da uf")]
    public class QuartoMigration : Migration
    {
        public override void Up()
        {
            Alter.Table("estado").AddColumn("sigla").AsString(2).Indexed();
        }

        public override void Down()
        {
            Delete.Column("sigla").FromTable("estado");
        }
    }
}
