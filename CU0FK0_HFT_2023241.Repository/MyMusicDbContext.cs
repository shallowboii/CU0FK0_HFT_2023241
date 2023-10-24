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
                string conn = "";
                builder.UseSqlServer()
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
            .HasForeignKey(song => song.ArtistID)
            .OnDelete(DeleteBehavior.Cascade)
                );

            modelBuilder.Entity<Artist>(artist => artist
            .HasMany(artist => artist.Albums)
            .WithOne(album => album.Artist)
            .HasForeignKey(artist => artist.AlbumID)
            .OnDelete(DeleteBehavior.Cascade)
            );
            
            
        }



    }
}
