using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private static readonly List<Car> cars = new List<Car> {
            new Car { CarId = 1, ChassisCodes = "AE86", price = 100_000 },
            new Car { CarId = 2, ChassisCodes = "FD3S", price = 200_000 },
            new Car { CarId = 3, ChassisCodes = "BNR32", price = 300_000 }
        };

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return cars;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IEnumerable<Car> Get(int id)
        {
            // LINQ: SQL style
            IEnumerable<Car> car = from c in cars
                                   where c.CarId == id
                                   select c;

            // LINQ: Lambda style
            car = cars.Where(c => c.CarId == id);

            return car;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public IEnumerable<Car> Post([FromBody] Car car)
        {
            cars.Add(car);

            return cars;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IEnumerable<Car> Put(int id, [FromBody] Car newCar)
        {
            // LINQ: SQL style
            Car? car = (from c in cars
                        where c.CarId == id
                        select c).SingleOrDefault();

            // LINQ: Lambda style
            car = cars.SingleOrDefault(c => c.CarId == id);

            if (car != null) {
                car.CarId = newCar.CarId;
                car.ChassisCodes = newCar.ChassisCodes;
                car.price = newCar.price;
            }

            return cars;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IEnumerable<Car> Delete(int id)
        {
            // LINQ: SQL style
            Car? car = (from c in cars
                        where c.CarId == id
                        select c).SingleOrDefault();

            // LINQ: Lambda style
            car = cars.SingleOrDefault(c => c.CarId == id);

            if (car != null) {
                cars.Remove(car);
            }

            return cars;
        }
    }
}
