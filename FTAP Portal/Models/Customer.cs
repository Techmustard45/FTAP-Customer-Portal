namespace FTAP_Portal.Models;

public class Customer
{
    public int CustomerID { get; set; }
    public string RacerName { get; set; }
    public int Proskill {get; set;}
    public int LoyaltyPoints {get; set;}
    public double AverageLaptime {get; set;}
    public double FastestLaptime {get; set;}
    public string Email { get; set; }
    public IEnumerable<Laptimes> Laptimes { get; set; }
}