using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Logic
{
    public class AlbumLogic : IAlbumLogic
    {
        IRepository<Album> repo;

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

    }
}
