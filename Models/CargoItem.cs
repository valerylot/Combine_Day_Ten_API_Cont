//this will Model one crate of cargo

//You can think of it as a form of an object

namespace Combine_Day_Ten_API_Cont.Models
{
    public class CargoItem
    {
        public int Id {get; set;} //get allows us to read, set allows us to change value
        public string Name {get; set;}
        public string Category {get; set;}
        public decimal Masskg {get; set;}

    }
}