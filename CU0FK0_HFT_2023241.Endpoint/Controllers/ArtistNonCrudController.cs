using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CU0FK0_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ArtistNonCrudController : ControllerBase
    {
        IArtistLogic artistLogic;

        public ArtistNonCrudController(IArtistLogic artistLogic)
        {
            this.artistLogic = artistLogic;
        }

        [HttpGet("{artistID}")]
        public IEnumerable<Album> AnArtistsBestAlbum(int artistID)
        {
            return artistLogic.AnArtistsBestAlbum(artistID);
        }
        [HttpGet("{artistID}")]
        public IEnumerable<double> ArtistsAvarageRating(int artistID)
        {
            return artistLogic.ArtistsAvarageRating(artistID);
        }
    }
}
