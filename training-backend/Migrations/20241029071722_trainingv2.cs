using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace training_backend.Migrations
{
    /// <inheritdoc />
    public partial class trainingv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Trainings",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Trainings");
        }
    }
}
