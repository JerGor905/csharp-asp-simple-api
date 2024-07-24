using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloWorldController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello", "World" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"[GET] id: {id}";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return $"[POST] request body: {value}";
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return $"[PUT] id: {id}\tvalue: {value}";
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"[DELETE] id: {id}";
        }
    }
}
