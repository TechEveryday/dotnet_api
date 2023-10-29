using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DotnetApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "app",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "attribute",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    typeid = table.Column<int>(name: "type_id", type: "integer", nullable: false),
                    entityid = table.Column<Guid>(name: "entity_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attribute", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "attribute_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attribute_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "entity",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    typeid = table.Column<int>(name: "type_id", type: "integer", nullable: false),
                    appid = table.Column<int>(name: "app_id", type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "entity_type",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "record",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true),
                    attributeid = table.Column<Guid>(name: "attribute_id", type: "uuid", nullable: false),
                    entityid = table.Column<Guid>(name: "entity_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_record", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "app");

            migrationBuilder.DropTable(
                name: "attribute");

            migrationBuilder.DropTable(
                name: "attribute_type");

            migrationBuilder.DropTable(
                name: "entity");

            migrationBuilder.DropTable(
                name: "entity_type");

            migrationBuilder.DropTable(
                name: "record");
        }
    }
}
