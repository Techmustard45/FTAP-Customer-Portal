using FTAP_Portal.Data;
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
}