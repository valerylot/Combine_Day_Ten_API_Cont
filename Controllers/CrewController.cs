using Combine_Day_Ten_API_Cont.Models;
using Microsoft.AspNetCore.Mvc;

namespace Combine_Day_Ten_API_Cont.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //-> /api/crew
    public class CrewController : ControllerBase
    {
        //OUR DATABASE FOR TODAY
        //A static means 1 shared copy for the whole application, so the data survives between requests

        private static List<CrewMember> Crew = [
            new CrewMember { Id = 1, Name = "Isaiah Ferguson", Rank = "Commander", Sector = "Command", IsOnDuty = true},
            new CrewMember { Id = 2, Name = "Chris Estrada", Rank = "Engineer", Sector = "Engineering", IsOnDuty = true},
            new CrewMember { Id = 3, Name = "Zackary Santos", Rank = "Medic", Sector = "Medical", IsOnDuty = false}    
        ];
        //this tracks the next id to hand out 
        private static int _nextId = 4;

        [HttpGet("GetAllMembers")]
        public ActionResult<List<CrewMember>> GetAll()
        {
            //200 Ok with the whole list
            return Ok(Crew);
        }

        [HttpGet("getmember/{id}")]
        public ActionResult<CrewMember>GetById(int id)
        {
            //FirstOrDefault returns null when nothing matches
            // => arrow function is a one liner for a method that returns the conditioned value
            CrewMember? member = Crew.FirstOrDefault(c => c.Id == id);

            if(member == null)
            {
                //404 client asked for id that does not exist
                return NotFound($"No crew member with id {id}.");
            }

            return Ok(member);
        }


        [HttpPost("Create")]
        public ActionResult<CrewMember> Create([FromBody] CrewMember incoming)
        {
            incoming.Id = _nextId;
            _nextId ++;

            Crew.Add(incoming);

            //201 Created is the correct status "I made something new"
            
            return CreatedAtAction(
                actionName: nameof(GetById),            //which action can GET the new thing
                routeValues: new {id = incoming.Id},    //this fills the id parameter in the action's route
                value: incoming                         //the body to sent back
            );
        }

        //REPLACE - UP

        //Put replaces the whole record (CrewMember) The client sends every field
        [HttpPut("Update/{id}")]
        public ActionResult<bool> Update(int id, [FromBody] CrewMember incoming)
        {                                       //crewMember is our parameter and we return the first result if the IDs match, but we can just use c for the first letter of the Model
            CrewMember? member = Crew.FirstOrDefault (crewMember => crewMember.Id == id);

            if(member == null)
            {
                return NotFound($"No crew member with id {id}");
            }
            
            //copy each field across. We deliberately do NOT copy the Id
            member.Name = incoming.Name;
            member.Rank = incoming.Rank;
            member.Sector = incoming.Sector;
            member.IsOnDuty = incoming.IsOnDuty;

            return Ok(true);
        }

        [HttpDelete("delete/{id}")]
        public ActionResult<bool> Delete(int id)
        {
            // ? means the member can be null
            CrewMember? member = Crew.FirstOrDefault(c => c.Id == id);

            if(member == null)
            {
                return NotFound($"No crew member with id {id}");
            }

            Crew.Remove(member);

            return Ok(true);
        }
    }
}