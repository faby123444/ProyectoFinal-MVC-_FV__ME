using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal_MVC__FV__ME.Migrations
{
    public partial class mssqlonprem_migration_447 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Registro_F",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semestre = table.Column<int>(type: "int", nullable: false),
                    Materia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profesor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cualidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registro_F", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Registro_F");
        }
    }
}
