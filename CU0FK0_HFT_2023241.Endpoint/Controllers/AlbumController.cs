using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace CU0FK0_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        IAlbumLogic logic;

        public AlbumController(IAlbumLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Album> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Album Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Album value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update( [FromBody] Album value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
