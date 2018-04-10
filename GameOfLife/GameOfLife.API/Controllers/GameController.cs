using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameOfLife.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        [HttpPost]
        [Route("NextGeneration")]
        public IActionResult NextGeneration([FromBody]Models.NextDataRequest value)
        {
            return new ObjectResult(new Models.NextDataRequest()
            {
                Data = new GameOfLife.GOF.Game().GetNextGeneration(value.Data)
            });
        }
    }
}