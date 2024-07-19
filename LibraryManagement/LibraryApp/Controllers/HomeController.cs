using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using LibraryInfra.Models;

using LibraryDomain.Interfaces;
namespace LibraryApp.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
private readonly IBookServices _bookService;
    public HomeController(ILogger<HomeController> logger,IBookServices bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
[HttpGet]
      public IActionResult Books()
    {
         var result = _bookService.GetBook();
        return View(result);
    }
[HttpGet]
   public IActionResult AddBooks()
    {
         return View();
    }

[HttpPost]
public IActionResult AddBooks(Book book)
{
    if(ModelState.IsValid)
    {
        _bookService.AddBooks(book);
        return RedirectToAction("Books");
    }
return View(book);
}

public IActionResult Delete(int id)
{
    if(id!=null)
    {
    _bookService.Delete(id);
    return RedirectToAction("Books");
    }
    return View(null);
}

[HttpGet]

public IActionResult Update(int id)
{
    var book=_bookService.GetBookById(id);

        return View(book);
    
}

[HttpPost]
public IActionResult Update(int id, Book book)
{
    if(id!=book.Id)
    {
            return NotFound();   
    }

    if(ModelState.IsValid)
    {
        _bookService.Update(id,book);
          return RedirectToAction("Books");
    }

    return View(book);
}


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
