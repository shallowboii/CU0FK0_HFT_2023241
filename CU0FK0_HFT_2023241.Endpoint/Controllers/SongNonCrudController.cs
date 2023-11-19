using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CU0FK0_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SongNonCrudController : ControllerBase
    {
        ISongLogic songLogic;

        public SongNonCrudController(ISongLogic songLogic)
        {
            this.songLogic = songLogic;
        }
        [HttpGet("{albumID}")]
        public IEnumerable<Song> AnAlbumsBestSong(int albumID)
        {
            return songLogic.AnAlbumsBestSong(albumID);
        }

    }
}
