using Microsoft.AspNetCore.Mvc;
using DigitalLibrary.Models;
using DigitalLibrary.Infraestructure;
using System;
using System.Linq;

namespace DigitalLibrary.Controllers;

public class BookController : Controller
{
    //Guarda el contexto para acceder a la base de datos
    private readonly AppDbContext _context;

    // Inyección de dependencias (para que el controlador pueda interacturar con EF
    public BookController(AppDbContext context)
    {
        _context = context;
    }

    // Lista de todos los libros
    // ------------------------------------------------------------
    public IActionResult Index()
    {
        var books = _context.Books.ToList();
        return View(books);
    }

    // Mostrar formulario de creación
    // ------------------------------------------------------------
    public IActionResult Create()
    {
        return View();
    }
    
    // Guarda y procesa el formulario
    public IActionResult SaveCreate(string name, string writer,DateOnly relased, int stock = 0)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Error = "El nombre del libro es obligatorio.";
                return View("Create");
            }

            
            var book = new Book
            {
                Name = name,
                Writer = writer,
                Relased = relased,
                Stock = stock
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Error creando libro: " + ex.Message;
            return View("Create");
        }
    }
    // ------------------------------------------------------------

    
    // Edit muestra el formulario de edicion 
    // ------------------------------------------------------------
    public IActionResult Edit(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        return View(book);
    }
    
    // SaveEdit
    public IActionResult SaveEdit(int id, string name, string writer,DateOnly relased, int stock = 0)
    {
        try
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                ViewBag.Error = "El libro no existe";
                return RedirectToAction("Index");
            }
            
            //Actualizar manualmente los campos
            book.Name = name;
            book.Writer = writer;
            book.Relased = relased;
            book.Stock = stock;
            
            //Guardar cambios
            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Error editando libro: " + ex.Message;
            return RedirectToAction("Index");
        }
    }
    // ------------------------------------------------------------

    // Delete se muestra la vista
    // ------------------------------------------------------------
    public IActionResult Delete(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        return View(book);
    }

    // ConfirmDelete
    public IActionResult ConfirmDelete(int id)
    {
        var book = _context.Books.Find(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    // ------------------------------------------------------------
}

