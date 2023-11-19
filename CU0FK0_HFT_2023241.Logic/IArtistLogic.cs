using CU0FK0_HFT_2023241.Models;
using System.Collections.Generic;
using System.Linq;

namespace CU0FK0_HFT_2023241.Logic
{
    public interface IArtistLogic
    {
        void Create(Artist item);
        void Delete(int id);
        Artist Read(int id);
        IQueryable<Artist> ReadAll();
        void Update(Artist item);
        IEnumerable<Album> AnArtistsBestAlbum(int artistID);
        IEnumerable<double> ArtistsAvarageRating(int artistID);
    }
}