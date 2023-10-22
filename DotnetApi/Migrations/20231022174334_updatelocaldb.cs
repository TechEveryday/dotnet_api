using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotnetApi.Migrations
{
    /// <inheritdoc />
    public partial class updatelocaldb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Record",
                table: "Record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entity",
                table: "Entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Attribute",
                table: "Attribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_App",
                table: "App");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntityType",
                table: "EntityType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeType",
                table: "AttributeType");

            migrationBuilder.RenameTable(
                name: "Record",
                newName: "record");

            migrationBuilder.RenameTable(
                name: "Entity",
                newName: "entity");

            migrationBuilder.RenameTable(
                name: "Attribute",
                newName: "attribute");

            migrationBuilder.RenameTable(
                name: "App",
                newName: "app");

            migrationBuilder.RenameTable(
                name: "EntityType",
                newName: "entity_type");

            migrationBuilder.RenameTable(
                name: "AttributeType",
                newName: "attribute_type");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "record",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "record",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "record",
                newName: "entity_id");

            migrationBuilder.RenameColumn(
                name: "AttributeId",
                table: "record",
                newName: "attribute_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "entity",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "entity",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "AppId",
                table: "entity",
                newName: "app_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "attribute",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "attribute",
                newName: "type_id");

            migrationBuilder.RenameColumn(
                name: "EntityId",
                table: "attribute",
                newName: "entity_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "app",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "app",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "entity_type",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "entity_type",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "attribute_type",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "attribute_type",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_record",
                table: "record",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entity",
                table: "entity",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_attribute",
                table: "attribute",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_app",
                table: "app",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entity_type",
                table: "entity_type",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_attribute_type",
                table: "attribute_type",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_record",
                table: "record");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entity",
                table: "entity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_attribute",
                table: "attribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_app",
                table: "app");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entity_type",
                table: "entity_type");

            migrationBuilder.DropPrimaryKey(
                name: "PK_attribute_type",
                table: "attribute_type");

            migrationBuilder.RenameTable(
                name: "record",
                newName: "Record");

            migrationBuilder.RenameTable(
                name: "entity",
                newName: "Entity");

            migrationBuilder.RenameTable(
                name: "attribute",
                newName: "Attribute");

            migrationBuilder.RenameTable(
                name: "app",
                newName: "App");

            migrationBuilder.RenameTable(
                name: "entity_type",
                newName: "EntityType");

            migrationBuilder.RenameTable(
                name: "attribute_type",
                newName: "AttributeType");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "Record",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Record",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "entity_id",
                table: "Record",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "attribute_id",
                table: "Record",
                newName: "AttributeId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Entity",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "Entity",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "app_id",
                table: "Entity",
                newName: "AppId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Attribute",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "Attribute",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "entity_id",
                table: "Attribute",
                newName: "EntityId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "App",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "App",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "EntityType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "EntityType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AttributeType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AttributeType",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Record",
                table: "Record",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entity",
                table: "Entity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Attribute",
                table: "Attribute",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_App",
                table: "App",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntityType",
                table: "EntityType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeType",
                table: "AttributeType",
                column: "Id");
        }
    }
}
