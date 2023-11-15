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

        public void Create(Album item) //3 tests done
        {
            if (item?.AlbumTitle.Length <= 2 || item is null)
            {
                throw new ArgumentException("Title is too short or none existent");
            }
            else
            {
                repo.Create(item);
            }

        }
        public void Delete(int id) // need like 2 tests
        {
            var album = repo.Read(id);
            if (album == null)
            {
                throw new ArgumentException();
            }
            else
            {
                repo.Delete(id);
            }
        }
        public Album Read(int id) // need like 2 tests
        {
            var album = repo.Read(id);
            if (album == null)
            {
                throw new ArgumentException("Album does not exits");
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
       //Ideas : If an album came out later than 2000 and artist is female
       //An artist Every album which songs has better rating than 7 
       //avarage rating : where artist = artist then get an avarage ratin in each album 

        public IEnumerable<Album> FemaleAlbumsLaterThan2012() //client tested +, tested
        {
            var albums = repo.ReadAll()
                .Where(t=>t.ReleaseYear>2012 && t.Artist.Gender=="Female")
                .AsEnumerable();
            return albums;
        }

        public IEnumerable<Song> EverySongFromAlbumBetterThan(double better) //client tested+ , tested
        {
            var songs = repo.ReadAll()
                .SelectMany(t => t.Songs)
                .Where(t => t.Album.Rating > better)
                .OrderBy(t => t.AlbumID)
                .ToList();

            return songs;
        }
         
        public IEnumerable<string> MostAmountOfAlbums() //client tested+, tested
        {
            var artistWithMostAlbums = repo.ReadAll()
                .AsEnumerable()
                .Select(t => t.Artist)
                .GroupBy(album => album.Albums)
                .OrderByDescending(group => group.Count())
                .FirstOrDefault()
                .Select(t => t.ArtistName)
                .FirstOrDefault();

            return new List<string> { artistWithMostAlbums };
        }

        #endregion

    }
}
