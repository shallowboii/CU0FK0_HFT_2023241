using CU0FK0_HFT_2023241.Models;
using System.Linq;

namespace CU0FK0_HFT_2023241.Logic
{
    public interface IAlbumLogic
    {
        void Create(Album item);
        void Delete(int id);
        Album Read(int id);
        IQueryable<Album> ReadAll();
        void Update(Album item);
    }
}