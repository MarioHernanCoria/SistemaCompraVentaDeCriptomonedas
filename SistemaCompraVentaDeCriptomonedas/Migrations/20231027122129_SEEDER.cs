using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaCompraVentaDeCriptomonedas.Migrations
{
    public partial class SEEDER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogMovimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailUsuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoCuenta = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    EmailDestino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCuentaDestino = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogMovimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genero = table.Column<int>(type: "int", nullable: false),
                    EstadoCivil = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<double>(type: "float", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    UUID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCripto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CBU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cuentas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MovimientoUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioOrigenId = table.Column<int>(type: "int", nullable: false),
                    UsuarioDestinoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoUsuarios_Usuarios_UsuarioDestinoId",
                        column: x => x.UsuarioDestinoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientoUsuarios_Usuarios_UsuarioOrigenId",
                        column: x => x.UsuarioOrigenId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roles_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoCuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuentaDestinoId = table.Column<int>(type: "int", nullable: false),
                    CuentaOrigenId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoCuentas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovimientoCuentas_Cuentas_CuentaDestinoId",
                        column: x => x.CuentaDestinoId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MovimientoCuentas_Cuentas_CuentaOrigenId",
                        column: x => x.CuentaOrigenId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovimientaCuentaId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovimientoUsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimientos_MovimientoCuentas_MovimientaCuentaId",
                        column: x => x.MovimientaCuentaId,
                        principalTable: "MovimientoCuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimientos_MovimientoUsuarios_MovimientoUsuarioId",
                        column: x => x.MovimientoUsuarioId,
                        principalTable: "MovimientoUsuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Activo", "Apellido", "Clave", "Dni", "Email", "EstadoCivil", "FechaNacimiento", "Genero", "Nombre" },
                values: new object[,]
                {
                    { 1, true, "Coria", "2191227b07660b208a127900f141134edcef520b5f2076f2c08884822e6cd610", 42863574, "mariocoria@gmail.com", 1, new DateTime(2000, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Mario" },
                    { 2, true, "Coria", "ab22d4230b674f95b0fdb601ec7cfc165ad11490114c41682fb13bcfcb5f2636", 78627162, "aliciacoria@gmail.com", 1, new DateTime(1969, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Alicia" },
                    { 3, true, "Gonzales", "f69dd9625a97f42a972022a56cf296baa70cdeb6a6d19eb475350bc083a99cbd", 60312412, "edwingonzales@gmail.com", 1, new DateTime(1969, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Edwin" },
                    { 4, true, "Solana", "b41ff9ad97f8d1a9a17487eeba8a3a4845f4b02463cb0cbd8cc149d9adb441cd", 25364734, "sergiosolana@gmail.com", 2, new DateTime(1950, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Sergio" },
                    { 5, true, "Silla", "c8f12ee6cffd196bddb03c00c87de5b1fc84f6b03aded3037b23f37f491922ba", 64392547, "marinasilla@gmail.com", 4, new DateTime(1963, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Marina" },
                    { 6, true, "Vargas", "1d3d8c6a59386ba8a3a2ba7e0ab06d1e42541b1ef885905c489339aeaba4e246", 9743265, "claudiavargas@gmail.com", 1, new DateTime(1962, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Claudia" },
                    { 7, true, "Vargas", "7e766bfcf2162b5587726043554e15ed3958853dfa03f91131268a08b6e6c321", 36598645, "raquelvargas@gmail.com", 1, new DateTime(1939, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Raquel" },
                    { 8, true, "Coria", "7a8eb7625e53f545e3400500bb2d4bdd2d9db24e8b9ce41572bda00e05062a48", 25463548, "anacoria@gmail.com", 2, new DateTime(1930, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Ana" },
                    { 9, true, "America", "acb31f97873213ab27504303c6a0278f8a187b7895ac088096031cd5ce981ef9", 26473645, "emiliaamerica@gmail.com", 1, new DateTime(2000, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Emilia" },
                    { 10, true, "Corbalan", "64c1f0da00856ac0e2d9f60bf54f10caa15cac59a5ac4365ff0c2a6b0ff2e6ee", 36475635, "dariocorbalan@gmail.com", 1, new DateTime(1980, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Dario" },
                    { 11, true, "Corbalan", "ae652caeb88b69447bec6e50422ae0795294392a4e5a6a4c5df924ff0506d7e2", 40265736, "fernandocorbalan@gmail.com", 1, new DateTime(2003, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Fernando" },
                    { 12, true, "Solan", "ab8ee9a8cf48414c7291b4f2f23b3a4b38e152988840636a4e61e981b03cb528", 35465768, "briansolana@gmail.com", 4, new DateTime(1990, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Brian" },
                    { 13, true, "Correa", "1df36b93d671df537144691e815d748064278b968f5a5096fc8ca056bf74885e", 24354623, "marianacorrea@gmail.com", 1, new DateTime(1998, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Mariana" },
                    { 14, true, "Vargas", "16f41ebf5bc518a46ca93700954646c161ea9316d4aa1cefaf388a90e79c0413", 97869785, "pablovargas@gmail.com", 1, new DateTime(2005, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Pablo" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Activo", "Descripcion", "Tipo", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, "ADMINISTRADOR", 1, 1 },
                    { 2, true, "CLIENTE", 2, 1 },
                    { 3, true, "OPERADOR", 3, 2 },
                    { 4, true, "ANALISTA", 4, 2 },
                    { 5, true, "AUDITOR", 5, 3 },
                    { 6, true, "USUARIO", 6, 1 },
                    { 7, true, "USUARIO", 6, 2 },
                    { 8, true, "USUARIO", 6, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UsuarioId",
                table: "Cuentas",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCuentas_CuentaDestinoId",
                table: "MovimientoCuentas",
                column: "CuentaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoCuentas_CuentaOrigenId",
                table: "MovimientoCuentas",
                column: "CuentaOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_MovimientaCuentaId",
                table: "Movimientos",
                column: "MovimientaCuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_MovimientoUsuarioId",
                table: "Movimientos",
                column: "MovimientoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoUsuarios_UsuarioDestinoId",
                table: "MovimientoUsuarios",
                column: "UsuarioDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoUsuarios_UsuarioOrigenId",
                table: "MovimientoUsuarios",
                column: "UsuarioOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_UsuarioId",
                table: "Roles",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogMovimientos");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "MovimientoCuentas");

            migrationBuilder.DropTable(
                name: "MovimientoUsuarios");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
