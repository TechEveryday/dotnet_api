using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetApi.Migrations
{
    /// <inheritdoc />
    public partial class EntityRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entity_relationship",
                columns: table => new
                {
                    childentityid = table.Column<Guid>(name: "child_entity_id", type: "uuid", nullable: false),
                    entityid = table.Column<Guid>(name: "entity_id", type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entity_relationship");
        }
    }
}
