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
        public DbSet<MovieRegisseur> MovieRegisseurs { get; set; }
        public DbSet<RegisseurMovieRegisseur> RegisseurMovieRegisseurs { get; set; }
        //podcast dbset
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<MediaWeb.Domain.Podcasts.Author> Authors { get; set; }
        public DbSet<AuthorPodcast> AuthorPodcasts { get; set; }
        //series dbset
        public DbSet<Serie> Series { get; set; }
        public DbSet<SerieGenre> SerieGenres { get; set; }
        public DbSet<GenreSerieGenre> GenreSerieGenres { get; set; }
        public DbSet<SerieRegisseur> SerieRegisseurs { get; set; }
        public DbSet<RegisseurSerieRegisseur> RegisseurSerieRegisseur { get; set; }
        //song dbset
        public DbSet<Song> Songs { get; set; }
        public DbSet<MediaWeb.Domain.Songs.Artist> Artists { get; set; }
        public DbSet<SongArtist> SongArtists { get; set; }
        public DbSet<SongGenre> SongGenres { get; set; }
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
                movie.Cover = updatedMovie.Cover;
            }
            this.SaveChanges();
        }

        //--------------------//
        // MovieGenre methods //
        //--------------------//

        public MovieGenre GetMovieGenre(int id)
        {
            return MovieGenres.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<MovieGenre> GetMovieGenres()
        {
            return MovieGenres;
        }

        public MovieGenre InsertMovieGenre(MovieGenre movieGenre)
        {
            MovieGenres.Add(movieGenre);
            this.SaveChanges();
            return movieGenre;
        }

        public void DeleteMovieGenre(int id)
        {
            var movieGenre = MovieGenres.SingleOrDefault(x => x.Id == id);
            if (movieGenre != null)
            {
                MovieGenres.Remove(movieGenre);
            }
            this.SaveChanges();
        }

        public void UpdateMovieGenre(int id, MovieGenre updatedMovieGenre)
        {
            var movieGenre = MovieGenres.SingleOrDefault(x => x.Id == id);
            if (movieGenre != null)
            {
                movieGenre.Name = updatedMovieGenre.Name;
                
            }
            this.SaveChanges();
        }


        //------------------------//
        // MovieRegisseur methods //
        //------------------------//
        public MovieRegisseur GetMovieRegisseur(int id)
        {
            return MovieRegisseurs.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<MovieRegisseur> GetMovieRegisseurs()
        {
            return MovieRegisseurs;
        }

        public MovieRegisseur InsertMovieRegisseur(MovieRegisseur movieRegisseur)
        {
            MovieRegisseurs.Add(movieRegisseur);
            this.SaveChanges();
            return movieRegisseur;
        }

        public void DeleteMovieRegisseur(int id)
        {
            var movieRegisseur = MovieRegisseurs.SingleOrDefault(x => x.Id == id);
            if (movieRegisseur != null)
            {
                MovieRegisseurs.Remove(movieRegisseur);
            }
            this.SaveChanges();
        }

        public void UpdateMovieRegisseur(int id, MovieRegisseur updatedMovieRegisseur)
        {
            var MovieRegisseur = MovieRegisseurs.SingleOrDefault(x => x.Id == id);
            if (MovieRegisseur != null)
            {
                MovieRegisseur.FirstName = updatedMovieRegisseur.FirstName;
                MovieRegisseur.Name = updatedMovieRegisseur.Name;
                MovieRegisseur.BirthDate = updatedMovieRegisseur.BirthDate;

            }
            this.SaveChanges();
        }

        //---------------//
        // Serie methods //
        //---------------//

        public Serie GetSerie(int id)
        {
            return Series.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Serie> GetSeries()
        {
            return Series;
        }

        public Serie InsertSerie(Serie serie)
        {
            Series.Add(serie);
            this.SaveChanges();
            return serie;
        }

        public void DeleteSerie(int id)
        {
            var serie = Series.SingleOrDefault(x => x.Id == id);
            if (serie != null)
            {
                Series.Remove(serie);
            }
            this.SaveChanges();
        }

        public void UpdateSerie(int id, Serie updatedSerie)
        {
            var serie = Series.SingleOrDefault(x => x.Id == id);
            if (serie != null)
            {
                serie.Name = updatedSerie.Name;
                serie.Genres = updatedSerie.Genres;
                serie.Regisseurs = updatedSerie.Regisseurs;
                serie.ReleaseDate = updatedSerie.ReleaseDate;

            }
            this.SaveChanges();
        }

        //--------------------//
        // SerieGenre methods //
        //--------------------//

        public SerieGenre GetSerieGenre(int id)
        {
            return SerieGenres.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<SerieGenre> GetSerieGenres()
        {
            return SerieGenres;
        }

        public SerieGenre InsertSerieGenre(SerieGenre serieGenre)
        {
            SerieGenres.Add(serieGenre);
            this.SaveChanges();
            return serieGenre;
        }

        public void DeleteSerieGenre(int id)
        {
            var serieGenre = SerieGenres.SingleOrDefault(x => x.Id == id);
            if (serieGenre != null)
            {
                SerieGenres.Remove(serieGenre);
            }
            this.SaveChanges();
        }

        public void UpdateSerieGenre(int id, SerieGenre updatedSerieGenre)
        {
            var serieGenre = SerieGenres.SingleOrDefault(x => x.Id == id);
            if (serieGenre != null)
            {
                serieGenre.Name = updatedSerieGenre.Name;
            }
            this.SaveChanges();
        }

        //------------------------//
        // SerieRegisseur methods //
        //------------------------//

        public SerieRegisseur GetSerieRegisseur(int id)
        {
            return SerieRegisseurs.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<SerieRegisseur> GetSerieRegisseurs()
        {
            return SerieRegisseurs;
        }

        public SerieRegisseur InsertSerieRegisseur(SerieRegisseur serieRegisseur)
        {
            SerieRegisseurs.Add(serieRegisseur);
            this.SaveChanges();
            return serieRegisseur;
        }

        public void DeleteSerieRegisseur(int id)
        {
            var serieRegisseur = SerieRegisseurs.SingleOrDefault(x => x.Id == id);
            if (serieRegisseur != null)
            {
                SerieRegisseurs.Remove(serieRegisseur);
            }
            this.SaveChanges();
        }

        public void UpdateSerieRegisseur(int id, SerieRegisseur updatedSerieRegisseur)
        {
            var serieRegisseur = SerieRegisseurs.SingleOrDefault(x => x.Id == id);
            if (serieRegisseur != null)
            {
                serieRegisseur.Name = updatedSerieRegisseur.Name;
                serieRegisseur.FirstName = updatedSerieRegisseur.FirstName;
                serieRegisseur.BirthDate = updatedSerieRegisseur.BirthDate;

            }
            this.SaveChanges();
        }

        //---------------//
        // Song methods //
        //---------------//

        public Song GetSong(int id)
        {
            return Songs.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Song> GetSongs()
        {
            return Songs;
        }

        public Song InsertSong(Song song)
        {
            Songs.Add(song);
            this.SaveChanges();
            return song;
        }

        public void DeleteSong(int id)
        {
            var song = Songs.SingleOrDefault(x => x.Id == id);
            if (song != null)
            {
                Songs.Remove(song);
            }
            this.SaveChanges();
        }

        public void UpdateSong(int id, Song updatedSong)
        {
            var song = Songs.SingleOrDefault(x => x.Id == id);
            if (song != null)
            {
                song.Name = updatedSong.Name;
                song.Genres = updatedSong.Genres;
                song.Artists = updatedSong.Artists;
                song.ReleaseDate = updatedSong.ReleaseDate;
                song.Length = updatedSong.Length;
            }
            this.SaveChanges();
        }

        //-------------------//
        // SongGenre methods //
        //-------------------//

        public SongGenre GetSongGenre(int id)
        {
            return SongGenres.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<SongGenre> GetSongGenres()
        {
            return SongGenres;
        }

        public SongGenre InsertSongGenre(SongGenre songGenre)
        {
            SongGenres.Add(songGenre);
            this.SaveChanges();
            return songGenre;
        }

        public void DeleteSongGenre(int id)
        {
            var songGenre = SongGenres.SingleOrDefault(x => x.Id == id);
            if (songGenre != null)
            {
                SongGenres.Remove(songGenre);
            }
            this.SaveChanges();
        }

        public void UpdateSongGenre(int id, SongGenre updatedSongGenre)
        {
            var songGenre = SongGenres.SingleOrDefault(x => x.Id == id);
            if (songGenre != null)
            {
                songGenre.Name = updatedSongGenre.Name;
            }
            this.SaveChanges();
        }

        //--------------------//
        // SongArtist methods //
        //--------------------//

        public Artist GetSongArtist(int id)
        {
            return Artists.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Artist> GetSongArtists()
        {
            return Artists;
        }

        public Artist InsertSongArtist(Artist artist)
        {
            Artists.Add(artist);
            this.SaveChanges();
            return artist;
        }

        public void DeleteSongArtist(int id)
        {
            var artist = Artists.SingleOrDefault(x => x.Id == id);
            if (artist != null)
            {
                Artists.Remove(artist);
            }
            this.SaveChanges();
        }

        public void UpdateSongArtist(int id, Artist updatedSongArtist)
        {
            var artist = Artists.SingleOrDefault(x => x.Id == id);
            if (artist != null)
            {
                artist.Name = updatedSongArtist.Name;
                artist.FirstName = updatedSongArtist.FirstName;
            }
            this.SaveChanges();
        }

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

        //-----------------------//
        // PodcastAuthor methods //
        //-----------------------//
        public Author GetPodcastAuthor(int id)
        {
            return Authors.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Author> GetPodcastAuthors()
        {
            return Authors;
        }

        public Author InsertPodcastAuthor(Author author)
        {
            Authors.Add(author);
            this.SaveChanges();
            return author;
        }

        public void DeletePodcastAuthor(int id)
        {
            var authors = Authors.SingleOrDefault(x => x.Id == id);
            if (authors != null)
            {
                Authors.Remove(authors);
            }
            this.SaveChanges();
        }

        public void UpdatePodcastAuthor(int id, Author updatedPodcastAuthor)
        {
            var author = Authors.SingleOrDefault(x => x.Id == id);
            if (author != null)
            {
                author.Name = updatedPodcastAuthor.Name;
                author.FirstName = updatedPodcastAuthor.FirstName;
            }
            this.SaveChanges();
        }

    }
}
