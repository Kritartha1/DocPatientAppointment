using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Appointment.API.Migrations
{
    public partial class Initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    qualifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hospital = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecords",
                columns: table => new
                {
                    MedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecords", x => x.MedId);
                });

            migrationBuilder.CreateTable(
                name: "Prescriptions",
                columns: table => new
                {
                    P_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.P_Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<float>(type: "real", nullable: true),
                    Weight = table.Column<float>(type: "real", nullable: true),
                    BloodGrp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    MedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MedicalRecordMedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_MedicalRecords_MedicalRecordMedId",
                        column: x => x.MedicalRecordMedId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedId");
                });

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    Dis_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dis_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrescriptionP_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.Dis_Id);
                    table.ForeignKey(
                        name: "FK_Diseases_Prescriptions_PrescriptionP_Id",
                        column: x => x.PrescriptionP_Id,
                        principalTable: "Prescriptions",
                        principalColumn: "P_Id");
                });

            migrationBuilder.CreateTable(
                name: "Appts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrescriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalRecordMedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appts_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appts_MedicalRecords_MedicalRecordMedId",
                        column: x => x.MedicalRecordMedId,
                        principalTable: "MedicalRecords",
                        principalColumn: "MedId");
                    table.ForeignKey(
                        name: "FK_Appts_Prescriptions_PrescriptionId",
                        column: x => x.PrescriptionId,
                        principalTable: "Prescriptions",
                        principalColumn: "P_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medications",
                columns: table => new
                {
                    MedicationsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DisId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiseaseDis_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medications", x => x.MedicationsId);
                    table.ForeignKey(
                        name: "FK_Medications_Diseases_DiseaseDis_Id",
                        column: x => x.DiseaseDis_Id,
                        principalTable: "Diseases",
                        principalColumn: "Dis_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appts_DoctorId",
                table: "Appts",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appts_MedicalRecordMedId",
                table: "Appts",
                column: "MedicalRecordMedId");

            migrationBuilder.CreateIndex(
                name: "IX_Appts_PrescriptionId",
                table: "Appts",
                column: "PrescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Appts_UserId",
                table: "Appts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseases_PrescriptionP_Id",
                table: "Diseases",
                column: "PrescriptionP_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Medications_DiseaseDis_Id",
                table: "Medications",
                column: "DiseaseDis_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MedicalRecordMedId",
                table: "Users",
                column: "MedicalRecordMedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appts");

            migrationBuilder.DropTable(
                name: "Medications");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "MedicalRecords");

            migrationBuilder.DropTable(
                name: "Prescriptions");
        }
    }
}
