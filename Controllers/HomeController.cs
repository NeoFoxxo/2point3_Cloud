using System.Diagnostics;
using _2point3_Cloud.Data;
using Microsoft.AspNetCore.Mvc;
using _2point3_Cloud.Models;

namespace _2point3_Cloud.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext _dataContext;
    
    public HomeController(ILogger<HomeController> logger, DataContext dataContext)
    {
        _logger = logger;
        _dataContext = dataContext;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ViewBooks()
    {
        List<Book> currentBooks = _dataContext.Books.ToList();
        return View(currentBooks);
    }
    
    public IActionResult AddBook()
    {
        return View();
    }
    
    public IActionResult SubmitBook(Book book)
    {
        _dataContext.Books.Add(book);
        _dataContext.SaveChanges();
        return RedirectToAction("ViewBooks");
    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}