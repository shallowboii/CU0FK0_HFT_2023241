using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Logic
{
    public class SongLogic : ISongLogic
    {
        IRepository<Song> repo;
        #region CRUD_METHODS
        public SongLogic(IRepository<Song> repo)
        {
            this.repo = repo;
        }

        public void Create(Song item)
        {
            if (item?.SongTitle.Length <= 2 || item is null)
            {
                throw new ArgumentException("Song does not exits or the title is too short!");
            }
            else
            {
                repo.Create(item);
            }

        }
        public void Delete(int id)
        {
            var song = repo.Read(id);
            if (song == null)
            {
                throw new ArgumentException("Song does not exits!");//Exception handling
            }
            else
            {
                repo.Delete(id);
            }
        }
        public Song Read(int id)
        {
            var song = repo.Read(id);
            if (song == null)
            {
                throw new ArgumentException("Song does not exits!");
            }
            return repo.Read(id);
        }
        public IQueryable<Song> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Song item)
        {
            try
            {
                Read(item.SongID);
                repo.Update(item);
            }
            catch (Exception)
            {
                throw new ArgumentException("Song does not exits!");
            }
        }
        #endregion


        public IEnumerable<Song> AnAlbumsBestSong(int albumID)
        {
            var songs = repo.ReadAll()
               .Where(t => t.AlbumID == albumID)
               .OrderByDescending(t => t.SongRating)
               .FirstOrDefault();
            if (songs != null)
            {
                return new List<Song> { songs };
            }
            else
            {
                throw new ArgumentException("The Album does not exits or it contains zero song!");
            }
        }
    }
}
