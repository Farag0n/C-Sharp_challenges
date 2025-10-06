using Microsoft.AspNetCore.Mvc;
using DigitalLibrary.Models;
using DigitalLibrary.Infraestructure;
using System;
using System.Linq;

namespace DigitalLibrary.Controllers;

public class BookController : Controller
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    // Lista todos los libros
    public IActionResult Index()
    {
        var books = _context.Books.ToList();
        return View(books);
    }

    // Mostrar formulario de creación
    public IActionResult Create()
    {
        return View();
    }

    // Procesar creación vía query string
    public IActionResult SaveCreate(string name, string writer = "", string relased = "", int stock = 0)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Error = "El nombre del libro es obligatorio.";
                return View("Create");
            }

            // Intentar parsear fecha; si no, usar la fecha de hoy
            DateOnly releaseDate;
            if (!DateOnly.TryParse(relased, out releaseDate))
            {
                releaseDate = DateOnly.FromDateTime(DateTime.Now);
            }

            var book = new Book
            {
                Name = name,
                Writer = string.IsNullOrWhiteSpace(writer) ? null : writer,
                Relased = releaseDate,
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

    // Edit (GET)
    public IActionResult Edit(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return RedirectToAction("Index");
        return View(book);
    }

    // SaveEdit (GET)
    public IActionResult SaveEdit(int id, string name, string writer = "", string relased = "", int stock = 0)
    {
        try
        {
            var book = _context.Books.Find(id);
            if (book == null) return RedirectToAction("Index");

            book.Name = name;
            book.Writer = string.IsNullOrWhiteSpace(writer) ? null : writer;

            DateOnly releaseDate;
            if (!DateOnly.TryParse(relased, out releaseDate))
            {
                releaseDate = book.Relased;
            }
            book.Relased = releaseDate;
            book.Stock = stock;

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

    // Delete (GET)
    public IActionResult Delete(int id)
    {
        var book = _context.Books.Find(id);
        if (book == null) return RedirectToAction("Index");
        return View(book);
    }

    // ConfirmDelete (GET)
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
}

