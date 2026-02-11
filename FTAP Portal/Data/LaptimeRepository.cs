using System.Data;
using FTAP_Portal.Models;
using Dapper;

namespace FTAP_Portal.Data;

public class LaptimeRepository : ILaptimeRepository
{
    private readonly IDbConnection _connection;

    public LaptimeRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    
    public IEnumerable<Laptimes> GetAllTimes()
    {
        return _connection.Query<Laptimes>("SELECT laptime, racername, kart, date FROM laptimes INNER JOIN customers ORDER BY laptime ASC;");
    }
}