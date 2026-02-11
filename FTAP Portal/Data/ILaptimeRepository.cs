using FTAP_Portal.Models;

namespace FTAP_Portal.Data;

public interface ILaptimeRepository
{
    public IEnumerable<Laptimes> GetAllTimes();
}