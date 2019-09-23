using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaWeb.Data.Migrations
{
    public partial class AddedProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorPodcasts_Author_AuthorId",
                table: "AuthorPodcasts");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreSongGenres_SongGenre_SongGenreId",
                table: "GenreSongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisseurMovieRegisseurs_MovieRegisseur_RegisseurId",
                table: "RegisseurMovieRegisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Artist_ArtistId",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenre_Songs_SongId",
                table: "SongGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongGenre",
                table: "SongGenre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieRegisseur",
                table: "MovieRegisseur");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artist",
                table: "Artist");

            migrationBuilder.DropColumn(
                name: "Comedy",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "Horror",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "HipHop",
                table: "SongGenre");

            migrationBuilder.DropColumn(
                name: "LoFi",
                table: "SongGenre");

            migrationBuilder.RenameTable(
                name: "SongGenre",
                newName: "SongGenres");

            migrationBuilder.RenameTable(
                name: "MovieRegisseur",
                newName: "MovieRegisseurs");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameTable(
                name: "Artist",
                newName: "Artists");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "SerieRegisseurs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "SerieRegisseurs",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "SerieGenres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Thriller",
                table: "MovieGenres",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "Rap",
                table: "SongGenres",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_SongGenre_SongId",
                table: "SongGenres",
                newName: "IX_SongGenres_SongId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Cover",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongGenres",
                table: "SongGenres",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieRegisseurs",
                table: "MovieRegisseurs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artists",
                table: "Artists",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorPodcasts_Authors_AuthorId",
                table: "AuthorPodcasts",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSongGenres_SongGenres_SongGenreId",
                table: "GenreSongGenres",
                column: "SongGenreId",
                principalTable: "SongGenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisseurMovieRegisseurs_MovieRegisseurs_RegisseurId",
                table: "RegisseurMovieRegisseurs",
                column: "RegisseurId",
                principalTable: "MovieRegisseurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Artists_ArtistId",
                table: "SongArtists",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenres_Songs_SongId",
                table: "SongGenres",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorPodcasts_Authors_AuthorId",
                table: "AuthorPodcasts");

            migrationBuilder.DropForeignKey(
                name: "FK_GenreSongGenres_SongGenres_SongGenreId",
                table: "GenreSongGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_RegisseurMovieRegisseurs_MovieRegisseurs_RegisseurId",
                table: "RegisseurMovieRegisseurs");

            migrationBuilder.DropForeignKey(
                name: "FK_SongArtists_Artists_ArtistId",
                table: "SongArtists");

            migrationBuilder.DropForeignKey(
                name: "FK_SongGenres_Songs_SongId",
                table: "SongGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SongGenres",
                table: "SongGenres");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieRegisseurs",
                table: "MovieRegisseurs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Artists",
                table: "Artists");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "SongGenres",
                newName: "SongGenre");

            migrationBuilder.RenameTable(
                name: "MovieRegisseurs",
                newName: "MovieRegisseur");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameTable(
                name: "Artists",
                newName: "Artist");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SerieRegisseurs",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "SerieRegisseurs",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SerieGenres",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "MovieGenres",
                newName: "Thriller");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SongGenre",
                newName: "Rap");

            migrationBuilder.RenameIndex(
                name: "IX_SongGenres_SongId",
                table: "SongGenre",
                newName: "IX_SongGenre_SongId");

            migrationBuilder.AddColumn<string>(
                name: "Comedy",
                table: "MovieGenres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Horror",
                table: "MovieGenres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HipHop",
                table: "SongGenre",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoFi",
                table: "SongGenre",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SongGenre",
                table: "SongGenre",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieRegisseur",
                table: "MovieRegisseur",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Artist",
                table: "Artist",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorPodcasts_Author_AuthorId",
                table: "AuthorPodcasts",
                column: "AuthorId",
                principalTable: "Author",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GenreSongGenres_SongGenre_SongGenreId",
                table: "GenreSongGenres",
                column: "SongGenreId",
                principalTable: "SongGenre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RegisseurMovieRegisseurs_MovieRegisseur_RegisseurId",
                table: "RegisseurMovieRegisseurs",
                column: "RegisseurId",
                principalTable: "MovieRegisseur",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongArtists_Artist_ArtistId",
                table: "SongArtists",
                column: "ArtistId",
                principalTable: "Artist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SongGenre_Songs_SongId",
                table: "SongGenre",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
