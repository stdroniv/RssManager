using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RssApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPostTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "UserPosts",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "UserPosts",
                newName: "Content");
        }
    }
}
