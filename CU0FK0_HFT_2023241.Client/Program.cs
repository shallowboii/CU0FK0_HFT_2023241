using ConsoleTools;
using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using System;
using System.Linq;

namespace CU0FK0_HFT_2023241.Client
{
    internal class Program
    {
        static SongLogic songlogic;
        static ArtistLogic artistLogic;
        static AlbumLogic albumLogic;

        static void Create(string entity)
        {
            Console.WriteLine(entity + " create");
            Console.ReadLine();
        }
        static void List(string entity)
        {
            if (entity == "Artist")
            {
                var items = artistLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.ArtistID + "\t" + item.ArtistName);
                }
            }
            else if (entity == "Song")
            {
                var items = songlogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.SongID + "\t" + item.SongTitle);
                }
            }
            
            else if (entity == "Album")
            {
                var items = albumLogic.ReadAll();
                Console.WriteLine("Id" + "\t" + "Name");
                foreach (var item in items)
                {
                    Console.WriteLine(item.AlbumID + "\t" + item.AlbumTitle);
                }
            }
            Console.ReadLine();

        }
        static void Update(string entity)
        {
            Console.WriteLine(entity + " update");
            Console.ReadLine();
        }
        static void Delete(string entity)
        {
            Console.WriteLine(entity + " delete");
            Console.ReadLine();
        }


        static void Main(string[] args)
        {
            var ctx = new MyMusicDbContext();

            var artistRepo = new ArtistRepository(ctx);
            var songRepo = new SongRepository(ctx);
            var albumRepo = new AlbumRepository(ctx);
            
            songlogic = new SongLogic(songRepo);
            artistLogic = new ArtistLogic(artistRepo);
            albumLogic = new AlbumLogic(albumRepo);

            var songs = albumLogic.EverySongFromAlbumBetterThan(0);
            var number = artistLogic.ArtistsAvarageRating(4);
            
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
