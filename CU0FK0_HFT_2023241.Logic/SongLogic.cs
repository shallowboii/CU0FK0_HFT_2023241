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
            if (item.SongTitle.Length < 2)
            {
                Console.WriteLine("Too short Song title");//Exception handling
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
                Console.WriteLine("Song doesn't exists!");//Exception handling
            }
            else
            {
                repo.Delete(id);
            }
        }
        public Song Read(int id)
        {
            var album = repo.Read(id);
            if (album == null)
            {
                Console.WriteLine("Song doesn't exists!");//Exception handling
            }
            return repo.Read(id);
        }
        public IQueryable<Song> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Song item)
        {
            repo.Update(item);
        }
        #endregion


        


    }
}
