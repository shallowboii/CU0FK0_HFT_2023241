using CU0FK0_HFT_2023241.Logic;
using CU0FK0_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CU0FK0_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        ISongLogic logic;

        public SongController(ISongLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Song> ReadAll()
        {
            return this.    logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Song Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Song value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Song value)
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
