using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Boost_Scheduler.API.Data;
using Microsoft.AspNetCore.Identity;

namespace Boost_Scheduler.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController: ControllerBase
    {
        /*/
        private Collection mainData;
        private List<Schedule> schedule {get;} = new List<Schedule>();
        private List<User> users {get;} = new List<User>();
        //*/
        private List<Game>? games {get;} = new List<Game>();
        /*/
        private List<Time> times {get;} = new List<Time>();
        //*/
        public DataController()
        {
            /*/
            string jsonFile = System.IO.File.ReadAllText("./Resources/data.json");
            mainData = JsonSerializer.Deserialize<Collection>(
                jsonFile,
                new JsonSerializerOptions{PropertyNameCaseInsensitive=true}
            );
            if (mainData != null)
            {
                schedule = mainData.schedule;
                users = mainData.users;
                games = mainData.games;
                times = mainData.times;
            }
            //*/   

            string jsonFile = System.IO.File.ReadAllText("./Resources/game.json");
            games = JsonSerializer.Deserialize<List<Game>>(
                jsonFile,
                new JsonSerializerOptions{PropertyNameCaseInsensitive=true}
            );
            /*/
            if (mainData != null)
            {
                games = mainData;
            }
            //*/
        }

        /*//
        // GET: api/Collection
        [HttpGet("Collection")]
        public ActionResult<Collection> GetCollection()
        {
            return Ok(mainData);
        }
        // GET: api/users
        [HttpGet("Users")]
        public ActionResult<List<User>> GetUsers()
        {
            return Ok(users);
        }
        //*/
        // GET: api/games
        [HttpGet("ListGames")]
        public IActionResult ListGames()
        {
            return Ok(games);
        }

        [HttpGet("ReadGame_{id}")]
        public IActionResult ReadGame(string id)
        {
            Predicate<Game> isFound = g => id == g.GameID;
            int index = games.FindIndex(isFound);
            return Ok(games[index]);
        }
        /*//
        // GET: api/times
        [HttpGet("Times")]
        public ActionResult<List<Time>> GetTimes()
        {
            return Ok(times);
        }

        // GET: api/Users/{id}
        [HttpGet("User{id}")]
        public ActionResult<Collection> GetUser(string id)
        {
            var user = users.FirstOrDefault(p => p.mainData.userID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        //*/
        //*/
        [HttpPost("CreateGame_{name}_{system}")]
        public IActionResult CreateGame(string name, string system)
        {
            var game = new Game();
            game.GameID = "temp";
            game.Name = name;
            game.System = system;
            games.Add(game);
            return CreatedAtAction(nameof(ListGames), new {gameID = "temp"}, game);
        }
/*///
        [HttpPut("PutGames_{id}_{name}_{system}")]
        public IActionResult PutGame(string id, string name, string system)
        {
            return NoContent();
        }
//*///
        [HttpDelete("DeleteGame_{id}")]
        public IActionResult DeleteGame(string id)
        {
            Predicate<Game> isFound = g => id == g.GameID;
            games.RemoveAt(games.FindIndex(isFound));
            // geeksforgeeks.org predicate with custom objects
            return NoContent();
        }

        [HttpPut("UpdateGames_{id}_{name}_{system}")]
        public IActionResult UpdateGame(string id, string name, string system)
        {
            Predicate<Game> isFound = g => id == g.GameID;
            int index = games.FindIndex(isFound);
            games[index].Name = name;
            games[index].System = system;
            return NoContent();
        }
        //*/
/*///
        [HttpPost]
        [HttpPatch]
        [HttpDelete]
        [HttpHead]
        [HttpOptions]
        [HttpPut]
//*///
    }
}