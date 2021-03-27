using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Ejecuciones.Migrations
{
    public partial class CreacionModelos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "municipios");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "departamentos",
                newName: "NombreDepartamento");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoMunicipio",
                table: "municipios",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(5)",
                oldMaxLength: 5);

            migrationBuilder.AddColumn<string>(
                name: "NombreMunicipio",
                table: "municipios",
                type: "character varying(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "cargos",
                columns: table => new
                {
                    CargoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    NombreCargo = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cargos", x => x.CargoId);
                });

            migrationBuilder.CreateTable(
                name: "despachos",
                columns: table => new
                {
                    DespachoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    NombreDespacho = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_despachos", x => x.DespachoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosProceso",
                columns: table => new
                {
                    EstadoProcesoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    NombreEstadoProceso = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosProceso", x => x.EstadoProcesoId);
                });

            migrationBuilder.CreateTable(
                name: "EstadosSolicitud",
                columns: table => new
                {
                    EstadoSolicitudId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    NombreEstadoSolicitud = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosSolicitud", x => x.EstadoSolicitudId);
                });

            migrationBuilder.CreateTable(
                name: "Fallador",
                columns: table => new
                {
                    FalladorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: false),
                    MunicipioId = table.Column<int>(type: "integer", nullable: false),
                    JuzgadoFallador = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fallador", x => x.FalladorId);
                    table.ForeignKey(
                        name: "FK_Fallador_departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fallador_municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "municipios",
                        principalColumn: "MunicipioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TiposSolicitud",
                columns: table => new
                {
                    TipoSolicitudId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    NombreSolicitud = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSolicitud", x => x.TipoSolicitudId);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Cedula = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Nombres = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    DespachoId = table.Column<int>(type: "integer", nullable: false),
                    CargoId = table.Column<int>(type: "integer", nullable: false),
                    CargoEmpleadoCargoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_funcionarios_cargos_CargoEmpleadoCargoId",
                        column: x => x.CargoEmpleadoCargoId,
                        principalTable: "cargos",
                        principalColumn: "CargoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_funcionarios_despachos_DespachoId",
                        column: x => x.DespachoId,
                        principalTable: "despachos",
                        principalColumn: "DespachoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Procesos",
                columns: table => new
                {
                    ProcesoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    DespachoId = table.Column<int>(type: "integer", nullable: false),
                    FechaProceso = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    RadicadoProceso = table.Column<string>(type: "text", nullable: false),
                    FalladorId = table.Column<int>(type: "integer", nullable: false),
                    AnexosSolicitud = table.Column<string>(type: "text", nullable: true),
                    CuadernosProceso = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    FoliosProceso = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    EstadoProcesoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesos", x => x.ProcesoId);
                    table.ForeignKey(
                        name: "FK_Procesos_despachos_DespachoId",
                        column: x => x.DespachoId,
                        principalTable: "despachos",
                        principalColumn: "DespachoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procesos_EstadosProceso_EstadoProcesoId",
                        column: x => x.EstadoProcesoId,
                        principalTable: "EstadosProceso",
                        principalColumn: "EstadoProcesoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Procesos_Fallador_FalladorId",
                        column: x => x.FalladorId,
                        principalTable: "Fallador",
                        principalColumn: "FalladorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Solicitudes",
                columns: table => new
                {
                    SolicitudId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    DespachoId = table.Column<int>(type: "integer", nullable: false),
                    TipoSolicitudId = table.Column<int>(type: "integer", nullable: false),
                    FechaSolicitud = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CedulaCondenado = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    NombresCondenado = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ApellidosCondenado = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    AnexosSolicitud = table.Column<string>(type: "text", nullable: true),
                    CuadernosSolicitud = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    FoliosSolicitud = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    EstadoSolicitudId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitudes", x => x.SolicitudId);
                    table.ForeignKey(
                        name: "FK_Solicitudes_despachos_DespachoId",
                        column: x => x.DespachoId,
                        principalTable: "despachos",
                        principalColumn: "DespachoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitudes_EstadosSolicitud_EstadoSolicitudId",
                        column: x => x.EstadoSolicitudId,
                        principalTable: "EstadosSolicitud",
                        principalColumn: "EstadoSolicitudId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Solicitudes_TiposSolicitud_TipoSolicitudId",
                        column: x => x.TipoSolicitudId,
                        principalTable: "TiposSolicitud",
                        principalColumn: "TipoSolicitudId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fallador_DepartamentoId",
                table: "Fallador",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Fallador_MunicipioId",
                table: "Fallador",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_CargoEmpleadoCargoId",
                table: "funcionarios",
                column: "CargoEmpleadoCargoId");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_DespachoId",
                table: "funcionarios",
                column: "DespachoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procesos_DespachoId",
                table: "Procesos",
                column: "DespachoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procesos_EstadoProcesoId",
                table: "Procesos",
                column: "EstadoProcesoId");

            migrationBuilder.CreateIndex(
                name: "IX_Procesos_FalladorId",
                table: "Procesos",
                column: "FalladorId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_DespachoId",
                table: "Solicitudes",
                column: "DespachoId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_EstadoSolicitudId",
                table: "Solicitudes",
                column: "EstadoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitudes_TipoSolicitudId",
                table: "Solicitudes",
                column: "TipoSolicitudId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "Procesos");

            migrationBuilder.DropTable(
                name: "Solicitudes");

            migrationBuilder.DropTable(
                name: "cargos");

            migrationBuilder.DropTable(
                name: "EstadosProceso");

            migrationBuilder.DropTable(
                name: "Fallador");

            migrationBuilder.DropTable(
                name: "despachos");

            migrationBuilder.DropTable(
                name: "EstadosSolicitud");

            migrationBuilder.DropTable(
                name: "TiposSolicitud");

            migrationBuilder.DropColumn(
                name: "NombreMunicipio",
                table: "municipios");

            migrationBuilder.RenameColumn(
                name: "NombreDepartamento",
                table: "departamentos",
                newName: "Nombre");

            migrationBuilder.AlterColumn<string>(
                name: "CodigoMunicipio",
                table: "municipios",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "municipios",
                type: "text",
                nullable: true);
        }
    }
}
