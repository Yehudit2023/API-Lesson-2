using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson2_BasicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {

        private static List<Event> _events = new List<Event>() { new Event { Id = 1, Title = "default event" ,Start=new DateTime(2023,11,12)} };

        private static int count = 1;//לסדר מונה שעלה את הid
       
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<Event> Get()
        {
            return _events;
            //return new string[] { "value1", "value2" };
        }



        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] Event eve)
        {
            count++;//לסדר מונה שעלה את הid
            _events.Add(new Event { Id = count, Title = eve.Title ,Start=eve.Start});
            
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Event eve)
        {
            var eve1 = _events.Find(item => item.Id == id);
            eve1.Title = eve.Title ;
            eve1.Start = eve.Start ;
            //eve1.End = eve.End ;

        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = _events.Find(item => item.Id == id);
            _events.Remove(eve);
        }
    }
}
