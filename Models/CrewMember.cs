//A model is just a normal C# class describing one thing your API works with 
//This will describe the shape of our data for our crew members
using Combine_Day_Ten_API_Cont.Controllers;

namespace Combine_Day_Ten_API_Cont.Models
{
    public class CrewMember
    {
        public int Id {get; set;} //every item needs a unique id so clients can address it 
        public string Name {get; set;} //get allows us to get the property value, and set allows us to change it
        public string Rank {get; set;}
        public string Sector {get; set;}
        public bool IsOnDuty {get; set;}
    }
}

//CrewMember crew = new CrewMember();
//crew.Name = "Chris"; <- this would be a set
//Console.WriteLine(crew.Name) <- this would be a get