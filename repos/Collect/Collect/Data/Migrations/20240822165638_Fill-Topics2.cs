using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Collect.Data.Migrations
{
    /// <inheritdoc />
    public partial class FillTopics2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Topic (TopicName) Values ('Books'), ('Signs'), ('Silverware'), ('Other')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
