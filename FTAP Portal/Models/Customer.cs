namespace FTAP_Portal.Models;

public class Customer
{
    public int customerid { get; set; }
    public string racername { get; set; }
    public int proskill {get; set;}
    public int loyaltypoints {get; set;}
    public double averagelaptime {get; set;}
    public double fastestlaptime {get; set;}
    public string email { get; set; }
    public IEnumerable<Laptimes> laptimes { get; set; }
}