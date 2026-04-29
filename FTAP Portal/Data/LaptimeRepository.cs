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
        return _connection.Query<Laptimes>("SELECT laptime, racername, kart, customers.customerid, laptimes.laptimeID FROM laptimes INNER JOIN customers WHERE customers.customerid = laptimes.customerid ORDER BY laptime ASC;");
    }

    public Customer GetRacer(int id)
    {
        var laptimeList = GetLaptimesForRacer(id);
        var customer = _connection.QuerySingle<Customer>(
            "SELECT c.customerid, c.RacerName, c.ProSkill, c.LoyaltyPoints, c.email,ROUND(AVG(l.LapTime),3) AS AverageLapTime,MIN(l.LapTime) AS FastestLapTime FROM Customers c JOIN Laptimes l ON c.CustomerID = l.CustomerID WHERE c.customerid = @id GROUP BY c.RacerName, c.ProSkill, c.LoyaltyPoints;",
            new { id });
        customer.laptimes = laptimeList;
        return customer;
    }

    public IEnumerable<Laptimes> GetLaptimesForRacer(int id)
    {
        return _connection.Query<Laptimes>("SELECT laptime, racername, kart, customers.customerid, laptimes.laptimeID FROM laptimes INNER JOIN customers WHERE laptimes.customerid = @id = customers.customerid ORDER BY laptime ASC;",
            new { id });
    }
    public void UpdateCustomer(Customer customer)
    {
        _connection.Execute("UPDATE customers SET racername = @racername, email = @email WHERE customerid = @id",
            new {racername = customer.racername, email = customer.email, id = customer.customerid });
    }

    public void AddLaptime(Laptimes laptimeToAdd)
    {
        _connection.Execute("INSERT INTO laptimes (LAPTIME, CUSTOMERID, KART) VALUES (@laptime, @customerid, @kart);",
            new { laptime = laptimeToAdd.laptime, customerid = laptimeToAdd.customerid, kart = laptimeToAdd.kart});
    }

    public Laptimes AssignCustomer(int id)
    {
        var customerid = GetRacer(id);
        var laptime = new Laptimes();
        laptime.customerid = customerid.customerid;
        return laptime;
    }
    
    public void DeleteLaptime(Laptimes laptimeToDelete)
    {
        _connection.Execute("DELETE FROM laptimes WHERE laptimes.LaptimeID = @id;", new { id = laptimeToDelete.LaptimeID });
    }
}