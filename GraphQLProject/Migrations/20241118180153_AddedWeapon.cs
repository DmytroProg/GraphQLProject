using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraphQLProject.Migrations
{
    /// <inheritdoc />
    public partial class AddedWeapon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeaponId",
                table: "Heroes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_WeaponId",
                table: "Heroes",
                column: "WeaponId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Weapons_WeaponId",
                table: "Heroes",
                column: "WeaponId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Weapons_WeaponId",
                table: "Heroes");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_WeaponId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "WeaponId",
                table: "Heroes");
        }
    }
}
