using FTAP_Portal.Data;
using FTAP_Portal.Models;
using Microsoft.AspNetCore.Mvc;

namespace FTAP_Portal.Controllers;

public class LaptimesController : Controller
{
    private readonly ILaptimeRepository _repo;

    public LaptimesController(ILaptimeRepository repo)
    {
        _repo = repo;
    }
    
    // GET
    public IActionResult Index()
    {
        var laptimes = _repo.GetAllTimes();
        return View(laptimes);
    }

    public IActionResult ViewRacer(int id)
    {
        var racer = _repo.GetRacer(id);
        return View(racer);
    }
    
    public IActionResult UpdateCustomer(int id)
    {
        var racer = _repo.GetRacer(id);
        if (racer == null)
        {
            return View("RacerNotFound");
        }
        return View(racer);
    }
    
    public IActionResult UpdateCustomerToDatabase(Customer customer)
    {
        _repo.UpdateCustomer(customer);

        return RedirectToAction("ViewRacer", new { id = customer.customerid });
    }

    public IActionResult AddLaptime(int id)
    {
        var laptime = _repo.AssignCustomer(id);
        return View(laptime);
    }
    
    public IActionResult AddLaptimeToDatabase(Laptimes laptimeToAdd)
    {
        _repo.AddLaptime(laptimeToAdd);
        return RedirectToAction("Index");
    }

    public IActionResult DeleteLaptimeFromDatabase(Laptimes laptimeToDelete)
    {
        _repo.DeleteLaptime(laptimeToDelete);
        return RedirectToAction("Index");
    }
}