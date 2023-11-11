using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        IRepository<Album> repo;

        #region CRUD_Methods
        public AlbumLogic(IRepository<Album> repo)
        {
            this.repo = repo;
        }

        public void Create(Album item)
        {
            if (item.AlbumTitle.Length < 2)
            {
                Console.WriteLine("Too short Album title");
            }
            else
            {
                repo.Create(item);
            }

        }
        public void Delete(int id)
        {
            var album = repo.Read(id);
            if (album == null)
            {
                Console.WriteLine("Album doesn't exists!");
            }
            else
            {
                repo.Delete(id);
            }
        }
        public Album Read(int id)
        {
            var album = repo.Read(id);
            if (album == null)
            {
                Console.WriteLine("Album doesn't exists!");
            }
            return repo.Read(id);
        }
        public IQueryable<Album> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Album item)
        {
            repo.Update(item);
        }
        #endregion


        #region NON_CRUD_Methods
        public IEnumerable<Album> BestAlbumOfArtist(int artistid)
        {
            var album = repo.ReadAll()
                .Where(t => t.ArtistID == artistid)
                .OrderByDescending(t => t.Rating)
                .FirstOrDefault();

             return new List<Album> { album };

            
        }
       //Ideas : If an album came out later than 2000 and artist is female
       //An artist Every album which songs has better rating than 7 
       //avarage rating : where artist = artist then get an avarage ratin in each album 

        public IEnumerable<Album> FemaleAlbumsLaterThan2012()
        {
            var albums = repo.ReadAll()
                .Where(t => t.Artist.Gender == "Female" && t.ReleaseYear > 2012)
                .OrderBy(t => t.ArtistID);
            return albums;
        }

        public IEnumerable<Song> EverySongFromAlbumBetterThan(double better)
        {
            var songs = repo.ReadAll()
                .SelectMany(t => t.Songs)
                .Where(t => t.Album.Rating > better)
                .OrderBy(t => t.AlbumID);

            return songs;
        }
        
        #endregion

    }
}
