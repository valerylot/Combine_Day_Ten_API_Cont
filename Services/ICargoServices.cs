//this is our menu
//interface as a contract
//it is a list of what our cargo sevices MUST do. This is NOT where the data is kept
using Combine_Day_Ten_API_Cont.Models;

namespace Combine_Day_Ten_API_Cont.Services
{
    public interface ICargoServices
    {
        //we are Creating, Updating, Reading, and Deleting from our Cargo database

        List<CargoItem> GetAll();

        List<CargoItem> GetByCategory(string Category);

        CargoItem GetById(int id);

        CargoItem Create(CargoItem item);

        bool Update(int id, CargoItem item);

        bool Delete (int id);
    }
}