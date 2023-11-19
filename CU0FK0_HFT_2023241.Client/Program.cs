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
        static void Delete(string entity)
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

        


        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:17161/","song");

            

            var ArtistSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Artist"))
                .Add("Create", () => Create("Artist"))
                .Add("Delete", () => Delete("Artist"))
                .Add("Update", () => Update("Artist"))
                .Add("Exit", ConsoleMenu.Close);

            var AlbumSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Album"))
                .Add("Create", () => Create("Album"))
                .Add("Delete", () => Delete("Album"))
                .Add("Update", () => Update("Album"))
                .Add("Exit", ConsoleMenu.Close);

            var SongSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Song"))
                .Add("Create", () => Create("Song"))
                .Add("Delete", () => Delete("Song"))
                .Add("Update", () => Update("Song"))
                .Add("Exit", ConsoleMenu.Close);

            var ElseSubMenu = new ConsoleMenu(args,level: 1)
                .Add("What do you want?",() => Console.Write("what"))
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Song", () => SongSubMenu.Show())
                .Add("Artist", () => ArtistSubMenu.Show())
                .Add("Album", () => AlbumSubMenu.Show())
                .Add("Else",()=> ElseSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
