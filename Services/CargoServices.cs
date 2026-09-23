//Cargo Services will be where our logic happens
//this is our kitchen
using Combine_Day_Ten_API_Cont.Models;

namespace Combine_Day_Ten_API_Cont.Services
{
    //ICargoServices is a PROMISE that this class will implement EVERY method within our Interface
    public class CargoServices : ICargoServices
    {
        private static List<CargoItem> _manifest = [ //the CargoItem in list is from the Models
            new CargoItem {Id = 1, Name = "Rations Packs", Category = "Food", Masskg = 240},
            new CargoItem {Id = 2, Name = "Battery Cells", Category = "Energy", Masskg = 1200},
            new CargoItem {Id = 3, Name = "Trauma Kits", Category = "Medical", Masskg = 55},
            new CargoItem {Id = 4, Name = "Healing Potion", Category = "Medical", Masskg = 10}
        ];
        //while our app runs static means it will keep track and not reset the value
        static int newId = 5;

        public List<CargoItem> GetAll()
        {
            return _manifest;
        }

        public List<CargoItem> GetByCategory(string category)
        {
            //we do not want to mutate our original list
            //we are putting our manifest in a copy so there isn't a chance where we mutate it
            //IEnumerable = list with specific rules, that you can ONLY iterate thru
            IEnumerable<CargoItem> result = _manifest;

            //Linq Queries are handy methods that we use to Query Lists / Databases
            //Language Integrated Query
            //Where filters out and then stores the condition in a list
            // => is called an arrow function / LMBDA a short hand for an anonymous function
            //this will run once per item c=> c.Category == category
            result = result.Where(c => c.Category == category);

            return result.ToList();
        }

        public CargoItem GetById(int id)
        {
            CargoItem? item = _manifest.FirstOrDefault(c => c.Id == id);

            return item;
        }

        public CargoItem Create(CargoItem item)
        {
            item.Id = newId;
            newId++;

            _manifest.Add(item);

            return item;
        }

        public bool Update(int id, CargoItem item)
        {
            //first or default checks the list against the condition i.Id == id
            //returns the first result or default (null)
            CargoItem? existing = _manifest.FirstOrDefault(i => i.Id == id);

            if (existing == null)
            {
                return false;
            }

            existing.Name = item.Name;
            existing.Category = item.Category;
            existing.Masskg = item.Masskg;

            return true;
        }

        public bool Delete(int id)
        {
            CargoItem? existingItem = _manifest.FirstOrDefault(t => t.Id == id);

            if (existingItem is null)
            {
                return false;
            }

            _manifest.Remove(existingItem);

            return true;
        }

    }
}