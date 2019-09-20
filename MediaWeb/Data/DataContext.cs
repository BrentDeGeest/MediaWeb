using MediaWeb.Domain.Movies;
using MediaWeb.Domain.Podcasts;
using MediaWeb.Domain.Series;
using MediaWeb.Domain.Songs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaWeb.Data
{
    public class DataContext : IdentityDbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        //movies dbset
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<GenreMovieGenre> GenreMovieGenres { get; set; }
        public DbSet<MovieRegisseur> MovieRegisseur { get; set; }
        public DbSet<RegisseurMovieRegisseur> RegisseurMovieRegisseurs { get; set; }
        //podcast dbset
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<AuthorPodcast> AuthorPodcasts { get; set; }
        //series dbset
        public DbSet<Serie> Series { get; set; }
        public DbSet<SerieGenre> SerieGenres { get; set; }
        public DbSet<GenreSerieGenre> GenreSerieGenres { get; set; }
        public DbSet<SerieRegisseur> SerieRegisseurs { get; set; }
        public DbSet<RegisseurSerieRegisseur> RegisseurSerieRegisseur { get; set; }
        //song dbset
        public DbSet<Song> Songs { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }
        public DbSet<SongGenre> SongGenre { get; set; }
        public DbSet<GenreSongGenre> GenreSongGenres { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GenreMovieGenre>().HasKey(movieGenre => new { movieGenre.GenreId, movieGenre.MovieId });
            modelBuilder.Entity<RegisseurMovieRegisseur>().HasKey(movieRegisseur => new { movieRegisseur.RegisseurId, movieRegisseur.MovieId });
            modelBuilder.Entity<GenreSerieGenre>().HasKey(serieGenre => new { serieGenre.GenreId, serieGenre.SerieId });
            modelBuilder.Entity<RegisseurSerieRegisseur>().HasKey(serieRegisseur => new { serieRegisseur.RegisseurId, serieRegisseur.SerieId });
            modelBuilder.Entity<GenreSongGenre>().HasKey(SongGenre => new { SongGenre.SongId, SongGenre.GenreId });
            modelBuilder.Entity<AuthorPodcast>().HasKey(authorPodcast => new { authorPodcast.PodcastId, authorPodcast.AuthorId });
            modelBuilder.Entity<SongArtist>().HasKey(songArtist => new { songArtist.ArtistId, songArtist.SongId });
        }

        //---------------//
        // Movie methods //
        //---------------//

        public Movie GetMovie(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return Movies;
        }

        public Movie InsertMovie(Movie movie)
        {
            Movies.Add(movie);
            this.SaveChanges();
            return movie;
        }
        public void DeleteMovie(int id)
        {
            var movie = Movies.SingleOrDefault(x => x.Id == id);
            if (movie != null)
            {
                Movies.Remove(movie);
            }
            this.SaveChanges();
        }

        public void UpdateMovie(int id, Movie updatedMovie)
        {
            var movie = Movies.SingleOrDefault(x => x.Id == id);
            if (movie != null)
            {
                movie.Title = updatedMovie.Title;
                movie.Description = updatedMovie.Description;
                movie.ReleaseDate = updatedMovie.ReleaseDate;
                movie.Length = updatedMovie.Length;
                movie.Genres = updatedMovie.Genres;
                movie.Regisseurs = updatedMovie.Regisseurs;
            }
            this.SaveChanges();
        }

        //--------------------//
        // MovieGenre methods //
        //--------------------//

        public Movie GetMovieGenre(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

       

        //------------------------//
        // MovieRegisseur methods //
        //------------------------//

        //-----------------//
        // Podcast methods //
        //-----------------//

        public Podcast GetPodcast(int id)
        {
            return Podcasts.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Podcast> GetPodcasts()
        {
            return Podcasts;
        }

        public Podcast InsertPodcast(Podcast podcast)
        {
            Podcasts.Add(podcast);
            this.SaveChanges();
            return podcast;
        }
        public void DeletePodcast(int id)
        {
            var podcast = Podcasts.SingleOrDefault(x => x.Id == id);
            if (podcast != null)
            {
                Podcasts.Remove(podcast);
            }
            this.SaveChanges();
        }

        public void UpdatePodcast(int id, Podcast updatedPodcast)
        {
            var podcast = Podcasts.SingleOrDefault(x => x.Id == id);
            if (podcast != null)
            {
                podcast.Title = updatedPodcast.Title;
                podcast.Authors = updatedPodcast.Authors;
                podcast.Length = updatedPodcast.Length;
            }
            this.SaveChanges();
        }

    }
}
