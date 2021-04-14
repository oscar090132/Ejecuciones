using Microsoft.EntityFrameworkCore.Migrations;

namespace Ejecuciones.Migrations
{
    public partial class control : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnexosSolicitud",
                table: "Procesos",
                newName: "AnexosProceso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnexosProceso",
                table: "Procesos",
                newName: "AnexosSolicitud");
        }
    }
}
