using Microsoft.AspNetCore.Mvc;
using DigitalLibrary.Models;
using DigitalLibrary.Infraestructure;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DigitalLibrary.Controllers;

public class BookLeadingController : Controller
{
    //Guarda el contexto para acceder he interactuar con la db
    private readonly AppDbContext _context;
    
    //Inyeccion de dependencias para interactuar con ef
    public BookLeadingController(AppDbContext context)
    {
        _context = context;
    }
    
    
    //Lista de prestamos
    // ------------------------------------------------------------
    public IActionResult Index()
    {
        var BLeadings = _context.BookLeadings.ToList();
        return View(BLeadings);
    }
    
    //Mostrar formulario de registro
    public IActionResult Create()
    {
        return View();
    }
    
    //Guarda y procesa el registro
    [HttpPost]
    public IActionResult Create(BookLeading loan)
    {
        try
        {
            var book = _context.Books.Find(loan.BookId);


            var bookLeading = _context.BookLeadings.Where(p => p.ID == 1)
                .Include(p => p.Book)
                .Include(p => p.User);

            foreach (var libro in bookLeading )
            {
                var usuario = libro.User.Name;
            }

            if (book.Stock < 1)
            {
                throw new Exception("No hay stock disponible.");
            }
            
            _context.BookLeadings.Add(loan);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewBag.Error = "Error generando el prestamo: " + e.Message;
            return View("Create");
        }
    }
    // ------------------------------------------------------------
    
    //Edit
    // ------------------------------------------------------------
    public IActionResult Edit(int id)
    {
        var bookLeading = _context.BookLeadings.Find(id);
        if (bookLeading == null)
        {
            return RedirectToAction("Index");
        }

        return View(bookLeading);
    }
    //Save Edit
    [HttpGet]
    public IActionResult Edit(int id, int userId, int bookId, DateOnly returnDate, bool returnState)
    {
        try
        {
            var bookLeading = _context.BookLeadings.Find(id);
            if (bookLeading == null)
            {
                throw new Exception("No hay stock disponible.");
            }

            //Actualizacion manual
            bookLeading.UserId = userId;
            bookLeading.BookId = bookId;
            bookLeading.ReturnDate = returnDate;
            bookLeading.ReturnState = returnState;

            _context.BookLeadings.Update(bookLeading);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (Exception e)
        {
            ViewBag.Error = "Error editanddo el prestamo: " + e.Message;
            return View("Create");
        }
    }
    
    // Delete se muestra la vista
    // ------------------------------------------------------------
    public IActionResult Delete(int id)
    {
        var bookLeading = _context.BookLeadings.Find(id);
        if (bookLeading == null)
        {
            return RedirectToAction("Index");
        }
        return View(bookLeading);
    }

    // ConfirmDelete
    public IActionResult ConfirmDelete(int id)
    {
        var bookLeading = _context.BookLeadings.Find(id);
        if (bookLeading != null)
        {
            _context.BookLeadings.Remove(bookLeading);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    // ------------------------------------------------------------
}