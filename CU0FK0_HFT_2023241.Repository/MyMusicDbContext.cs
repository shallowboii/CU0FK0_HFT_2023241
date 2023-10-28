using CU0FK0_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CU0FK0_HFT_2023241.Repository
{
    public class MyMusicDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }


        public MyMusicDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MyMusicDb.mdf;Integrated Security=True;MultipleActiveResultSets=true";
                builder.UseSqlServer(conn)
                    .UseLazyLoadingProxies();
                    
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(album => album
            .HasOne(album => album.Artist)
            .WithMany(artist => artist.Albums)
            .HasForeignKey(album => album.ArtistID)
            .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Song>(song => song
            .HasOne(song => song.Album)
            .WithMany(album => album.Songs)
            .HasForeignKey(song => song.AlbumID)
            .OnDelete(DeleteBehavior.Cascade));


            //modelBuilder.Entity<Artist>(artist => artist
            //.HasMany(artist => artist.Albums)
            //.WithOne(album => album.Artist)
            //.HasForeignKey(artist => artist.AlbumID)
            //.OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album(1,"Igor",1),
                new Album(2,"FlowerBoy",1),
                new Album(3,"Blonde",2)
            }
                );

            modelBuilder.Entity<Song>().HasData(new Song[]
            {
                new Song(1,"Earfquake",170,1),
                new Song(2,"Nikes",220,3),
                new Song(3,"See You Again",100,2)
            }
                );
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist(1,"Tyler The Creator"),
                new Artist(2,"Frank Ocean"),
                new Artist(3,"Madonna")
            });
            
        }




    }
}
