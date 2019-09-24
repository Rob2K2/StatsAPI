using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using StatsAPI.DAL;
using StatsAPI.Models;

namespace StatsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        private readonly UserDAL userDAL = new UserDAL();

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPut("{option}")]
        public IActionResult Put(string option, [FromBody] User user)
        {
            var userKudos = userDAL.ObtenerUsuario(user.UserID);
            int totalKudos = userKudos.TotalKudos;

            if (option == "add")
            {
                totalKudos++;
            }
            else
            {
                totalKudos--;
            }

            bool resultado = userDAL.UpdateUserKudos(user.UserID, totalKudos);

            if (!resultado)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}