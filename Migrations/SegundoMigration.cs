using FluentMigrator;

namespace MigrationSemEF.Migrations
{
    [Migration(2021_04_15_21_10, "Criar a tabela de cidades")]
    public class SegundoMigration : Migration
    {
        public override void Up()
        {
            Create.Table("cidade")
                .WithDescription("Guarda os dados das cidades")
                .WithColumn("id").AsInt32().PrimaryKey().Identity().WithColumnDescription("Chave primária da tabela")
                .WithColumn("ibge").AsInt32().NotNullable().WithColumnDescription("Código IBGE da cidade")
                .WithColumn("nome").AsString(100).NotNullable().WithColumnDescription("Nome da cidade")
                .WithColumn("idEstado").AsInt32().ForeignKey("estado", "id");
        }

        public override void Down()
        {
            Delete.Table("cidade");
        }
    }
}
