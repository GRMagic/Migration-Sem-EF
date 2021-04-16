using FluentMigrator;

namespace MigrationSemEF.Migrations
{
    [Migration(2021_04_15_20_00, "Criar a tabela de estados (UF)")]
    public class PrimeiroMigration : Migration
    {
        public override void Up()
        {
            Create.Table("estado")
                .WithDescription("Guarda os dados das UFs")
                .WithColumn("id").AsInt32().PrimaryKey().Identity().WithColumnDescription("Chave primária da tabela")
                .WithColumn("ibge").AsInt32().NotNullable().WithColumnDescription("Código IBGE do estado")
                .WithColumn("nome").AsString(100).NotNullable().WithColumnDescription("Nome do estado");
        }

        public override void Down()
        {
            Delete.Table("estado");
        }
    }
}
