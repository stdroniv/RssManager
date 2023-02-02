using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RssApi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SimplePost_UserRssFeeds_UserRssFeedUserId_UserRssFeedFeedUri",
                table: "SimplePost");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SimplePost",
                table: "SimplePost");

            migrationBuilder.RenameTable(
                name: "SimplePost",
                newName: "UserPosts");

            migrationBuilder.RenameIndex(
                name: "IX_SimplePost_UserRssFeedUserId_UserRssFeedFeedUri",
                table: "UserPosts",
                newName: "IX_UserPosts_UserRssFeedUserId_UserRssFeedFeedUri");

            migrationBuilder.AlterColumn<string>(
                name: "UserRssFeedUserId",
                table: "UserPosts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserRssFeedFeedUri",
                table: "UserPosts",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FeedUri",
                table: "UserPosts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserPosts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPosts",
                table: "UserPosts",
                column: "PostUri");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosts_UserRssFeeds_UserRssFeedUserId_UserRssFeedFeedUri",
                table: "UserPosts",
                columns: new[] { "UserRssFeedUserId", "UserRssFeedFeedUri" },
                principalTable: "UserRssFeeds",
                principalColumns: new[] { "UserId", "FeedUri" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPosts_UserRssFeeds_UserRssFeedUserId_UserRssFeedFeedUri",
                table: "UserPosts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPosts",
                table: "UserPosts");

            migrationBuilder.DropColumn(
                name: "FeedUri",
                table: "UserPosts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserPosts");

            migrationBuilder.RenameTable(
                name: "UserPosts",
                newName: "SimplePost");

            migrationBuilder.RenameIndex(
                name: "IX_UserPosts_UserRssFeedUserId_UserRssFeedFeedUri",
                table: "SimplePost",
                newName: "IX_SimplePost_UserRssFeedUserId_UserRssFeedFeedUri");

            migrationBuilder.AlterColumn<string>(
                name: "UserRssFeedUserId",
                table: "SimplePost",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "UserRssFeedFeedUri",
                table: "SimplePost",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SimplePost",
                table: "SimplePost",
                column: "PostUri");

            migrationBuilder.AddForeignKey(
                name: "FK_SimplePost_UserRssFeeds_UserRssFeedUserId_UserRssFeedFeedUri",
                table: "SimplePost",
                columns: new[] { "UserRssFeedUserId", "UserRssFeedFeedUri" },
                principalTable: "UserRssFeeds",
                principalColumns: new[] { "UserId", "FeedUri" });
        }
    }
}
