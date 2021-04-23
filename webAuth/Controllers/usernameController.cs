using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webAuth.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class usernameController : ControllerBase
    {
        private readonly authenticationManager authenticationManagerClass;

        //interface and the controller
        public usernameController(authenticationManager authenticationManagerClass)
        {
            this.authenticationManagerClass = authenticationManagerClass;
        }

        // GET: api/username
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {
               "cdemangeon4@epa.gov", "ereedie0@godaddy.com", "wedgin1@woothemes.com", "oheaven2@house.gov", "ainde3@elpais.com",
               "kpiser5@meetup.com","pdanis6@java.com","dmoller7@w3.org","wtouhig8@huffingtonpost.com","pduell9@unblog.fr"
            };
        }

        // GET: api/username/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [AllowAnonymous]
        [HttpPost("auth")]
        public IActionResult auth([FromBody] UserCred userCred)
        {
            var token = authenticationManagerClass.Authenticate(userCred.Username, userCred.Password);
                if (token == null)
                return Unauthorized();
                return Ok(token);
        }
    }
}
