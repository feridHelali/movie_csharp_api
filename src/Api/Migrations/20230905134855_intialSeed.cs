using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class intialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "DateOfBirth", "Fortune", "Name" },
                values: new object[,]
                {
                    { 3, new DateTime(1944, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4585200m, "Sauel JAKSON" },
                    { 4, new DateTime(1971, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 7985200m, "Julia ROBERTS" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "InTheater", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 3, false, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Evengers" },
                    { 4, false, new DateTime(2001, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brave Hart" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Content", "MovieId", "Recommend" },
                values: new object[] { 6, "The suspense till the End", 3, true });

            migrationBuilder.InsertData(
                table: "GenreMovie",
                columns: new[] { "GenresIdentifier", "MoviesId" },
                values: new object[] { 3, 3 });

            migrationBuilder.InsertData(
                table: "MovieActors",
                columns: new[] { "ActorId", "MovieId", "Character", "Order" },
                values: new object[] { 3, 4, "The King", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "GenreMovie",
                keyColumns: new[] { "GenresIdentifier", "MoviesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "MovieActors",
                keyColumns: new[] { "ActorId", "MovieId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Actors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
