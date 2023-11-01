using CU0FK0_HFT_2023241.Models;
using CU0FK0_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CU0FK0_HFT_2023241.Logic
{
    public class ArtistLogic : IArtistLogic
    {
        IRepository<Artist> repo;

        public ArtistLogic(IRepository<Artist> repo)
        {
            this.repo = repo;
        }

        public void Create(Artist item)
        {
            repo.Create(item);
        }
        public void Delete(int id)
        {
            var album = repo.Read(id);
            if (album == null)
            {
                Console.WriteLine("Artist doesn't exists!");//Exception handling
            }
            else
            {
                repo.Delete(id);
            }
        }
        public Artist Read(int id)
        {
            var album = repo.Read(id);
            if (album == null)
            {
                Console.WriteLine("Artist doesn't exists!");//Exception handling
            }
            return repo.Read(id);
        }
        public IQueryable<Artist> ReadAll()
        {
            return repo.ReadAll();
        }
        public void Update(Artist item)
        {
            repo.Update(item);
        }

    }
}
