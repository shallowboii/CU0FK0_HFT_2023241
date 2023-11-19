using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CU0FK0_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AlbumNonCrudController : ControllerBase
    {
        IAlbumLogic albumlogic;

        public AlbumNonCrudController(IAlbumLogic albumlogic)
        {
            this.albumlogic = albumlogic;
        }

        [HttpGet]
        public IEnumerable<Album> FemaleAlbumsLaterThan2012()
        {
            return albumlogic.FemaleAlbumsLaterThan2012();
        }
        [HttpGet("{better}")]

        public IEnumerable<Song> EverySongFromAlbumBetterThan(double better)
        {
            return albumlogic.EverySongFromAlbumBetterThan(better);
        }

        [HttpGet]
        public IEnumerable<string> MostAmountOfAlbums()
        {
            return albumlogic.MostAmountOfAlbums();
        }

        
    }
}
