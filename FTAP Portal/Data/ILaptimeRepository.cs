using FTAP_Portal.Models;

namespace FTAP_Portal.Data;

public interface ILaptimeRepository
{
    public IEnumerable<Laptimes> GetAllTimes();
    public Customer GetRacer(int id);
    public IEnumerable<Laptimes> GetLaptimesForRacer(int id);
    void UpdateCustomer(Customer customer);
    void AddLaptime(Laptimes laptimeToAdd);
    public Laptimes AssignCustomer(int id);
    public void DeleteLaptime(Laptimes laptimeToDelete);
}