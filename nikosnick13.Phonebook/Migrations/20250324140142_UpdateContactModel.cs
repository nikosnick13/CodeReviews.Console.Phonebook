using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nikosnick13.Phonebook.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emai",
                table: "Contacts",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Contacts",
                newName: "Emai");
        }
    }
}
