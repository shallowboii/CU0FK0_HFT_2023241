using CU0FK0_HFT_2023241.Models;
using System.Linq;

namespace CU0FK0_HFT_2023241.Logic
{
    public interface ISongLogic
    {
        void Create(Song item);
        void Delete(int id);
        Song Read(int id);
        IQueryable<Song> ReadAll();
        void Update(Song item);
    }
}