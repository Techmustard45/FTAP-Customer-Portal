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
        return _connection.Query<Laptimes>("SELECT laptime, racername, kart, laptimes.customerid FROM laptimes INNER JOIN customers ORDER BY laptime ASC;");
    }

    public Customer GetRacer(string id)
    {
        return _connection.QuerySingle<Customer>(
            "SELECT customers.customerid, racername, proskill, loyaltypoints, ROUND(AVG(laptime), 3) AS averagelaptime, MIN(laptime) AS fastestlaptime FROM customers INNER JOIN laptimes WHERE customers.customerid = @id;",
            new { id });
    }
}