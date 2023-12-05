using ConsoleTools;
using CU0FK0_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CU0FK0_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        
        static void Create(string entity)
        {
            try
            {
                if (entity == "Artist")
                {
                    Console.WriteLine("Enter Artist Name: ");
                    string name = Console.ReadLine();
                    rest.Post(new Artist() { ArtistName = name }, "artist");
                }
                else if (entity == "Song")
                {
                    Console.WriteLine("Enter Song Name: ");
                    string name = Console.ReadLine();
                    rest.Post(new Song() { SongTitle = name }, "song");
                }
                else if (entity == "Album")
                {
                    Console.WriteLine("Enter Album Name: ");
                    string name = Console.ReadLine();
                    rest.Post(new Album() { AlbumTitle = name }, "album");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        static void List(string entity)
        {
            if (entity == "Artist")
            {
                List<Artist> artists = rest.Get<Artist>("artist");
                foreach (var item in artists)
                {
                    Console.WriteLine(item.ArtistID + ": " + item.ArtistName);
                }
            }
            else if (entity == "Song")
            {
                List<Song> songs = rest.Get<Song>("song");
                foreach (var item in songs)
                {
                    Console.WriteLine(item.SongID + ": " + item.SongTitle);
                }
            }
            
            else if (entity == "Album")
            {
                List<Album> albums = rest.Get<Album>("album");
                foreach (var item in albums)
                {
                    Console.WriteLine(item.AlbumID + ": " + item.AlbumTitle);
                }
            }
            Console.ReadLine();

        }
        static void Update(string entity)
        {
            try
            {
                if (entity == "Artist")
                {
                    Console.Write("Enter Artist's id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Artist one = rest.Get<Artist>(id, "artist");
                    Console.Write($"New name [old: {one.ArtistName}]: ");
                    string name = Console.ReadLine();
                    one.ArtistName = name;
                    rest.Put(one, "artist");
                }
                else if (entity == "Song")
                {
                    Console.Write("Enter Song's id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Song one = rest.Get<Song>(id, "song");
                    Console.Write($"New name [old: {one.SongTitle}]: ");
                    string name = Console.ReadLine();
                    one.SongTitle = name;
                    rest.Put(one, "song");
                }
                else if (entity == "Album")
                {
                    Console.Write("Enter Album's id to update: ");
                    int id = int.Parse(Console.ReadLine());
                    Album one = rest.Get<Album>(id, "album");
                    Console.Write($"New name [old: {one.AlbumTitle}]: ");
                    string name = Console.ReadLine();
                    one.AlbumTitle = name;
                    rest.Put(one, "album");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();

            }
        }
        static void Delete(string entity)
        {
            try
            {
                if (entity == "Artist")
                {
                    Console.Write("Enter Artist's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "artist");
                }
                else if (entity == "Song")
                {
                    Console.Write("Enter Song's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "song");
                }

                else if (entity == "Album")
                {
                    Console.Write("Enter Album's id to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    rest.Delete(id, "album");
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        static void AnArtistsBestAlbum(string entity)
        {
            try
            {
                Console.Write("Enter Artist's ID:");
                string beker = Console.ReadLine();
                int id = int.Parse(beker);
                var albums = rest.GetArtistBestAlbum<Album>(entity, "AnArtistsBestAlbum", id);
                Console.WriteLine("Album:");
                if (albums.ElementAtOrDefault(0)==null)
                {
                    Console.WriteLine("Artist does not have an album in our database");
                }
                else
                {
                    foreach (var album in albums)
                    {
                        Console.WriteLine(album.AlbumTitle + " and it's rating is : " + album.Rating);
                    }
                }
                
                Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        static void ArtistsAvarageRating(string entity)
        {
            try
            {
                Console.Write("Enter Artist's ID:");
                int id = int.Parse(Console.ReadLine());
                var results = rest.GetArtistsAvarageRating<double>(entity, "ArtistsAvarageRating", id);
                var artist = rest.Get<Artist>(id, "artist");
                Console.WriteLine("Album:");
                foreach (var result in results)
                {
                    Console.WriteLine(artist.ArtistName + ": " + result);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        static void AnAlbumsBestSong(string entity)
        {
            try
            {
                Console.Write("Enter Album's ID:");
                int id = int.Parse(Console.ReadLine());
                var results = rest.GetAnAlbumsBestSong<Song>(entity, "AnAlbumsBestSong", id);
                var album = rest.Get<Album>(id, "album");
                Console.WriteLine("Song:");
                foreach (var result in results)
                {
                    Console.WriteLine(album.AlbumTitle + "'s Best song is : " + result.SongTitle);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        static void FemaleAlbumsLaterThan2012(string entity)
        {
            try
            {
                var results = rest.GetFemaleAlbumsLaterThan2012<Album>(entity, "FemaleAlbumsLaterThan2012");
                Console.WriteLine("Albums:");
                foreach (var result in results)
                {
                    Console.WriteLine(result.AlbumTitle + "by:" + result.Artist.ArtistName);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
        static void EverySongFromAlbumBetterThan(string entity)
        {
            try
            {
                Console.Write("Enter a number (The rating is between 1-5):");
                double better = Convert.ToDouble(Console.ReadLine());
                var results = rest.GetEverySongFromAlbumBetterThan<Song>(entity, "EverySongFromAlbumBetterThan", better);
                Console.WriteLine("Songs:");
                foreach (var result in results)
                {
                    Console.WriteLine(result.SongTitle + "in:" + result.Album.AlbumTitle);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        static void MostAmountOfAlbums(string entity)
        {
            try
            {
                var results = rest.GetMostAmountOfAlbums<string>(entity, "MostAmountOfAlbums");
                Console.WriteLine("The who has the most amout of Albums:");
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:17161/","song");

            

            var ArtistSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Artist"))
                .Add("Create", () => Create("Artist"))
                .Add("Delete", () => Delete("Artist"))
                .Add("Update", () => Update("Artist"))
                .Add("ArtistsAvarageRating", () => ArtistsAvarageRating("ArtistNonCrud"))
                .Add("AnArtistsBestAlbum", ()=>AnArtistsBestAlbum("ArtistNonCrud"))
                .Add("Exit", ConsoleMenu.Close);

            var AlbumSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Album"))
                .Add("Create", () => Create("Album"))
                .Add("Delete", () => Delete("Album"))
                .Add("Update", () => Update("Album"))
                .Add("FemaleAlbumsLaterThan2012",()=> FemaleAlbumsLaterThan2012("AlbumNonCrud"))
                .Add("EverySongFromAlbumBetterThan", () => EverySongFromAlbumBetterThan("AlbumNonCrud"))
                .Add("MostAmountOfAlbums", () => MostAmountOfAlbums("AlbumNonCrud"))
                .Add("Exit", ConsoleMenu.Close);

            var SongSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Song"))
                .Add("Create", () => Create("Song"))
                .Add("Delete", () => Delete("Song"))
                .Add("Update", () => Update("Song"))
                .Add("AnAlbumsBestSong", ()=> AnAlbumsBestSong("SongNonCrud"))
                .Add("Exit", ConsoleMenu.Close);

            var ElseSubMenu = new ConsoleMenu(args,level: 1)
                .Add("What do you want?",() => Console.Write("what"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Song", () => SongSubMenu.Show())
                .Add("Artist", () => ArtistSubMenu.Show())
                .Add("Album", () => AlbumSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
