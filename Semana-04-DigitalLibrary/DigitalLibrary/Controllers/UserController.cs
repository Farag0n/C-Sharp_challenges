using Microsoft.AspNetCore.Mvc;
using DigitalLibrary.Models;
using DigitalLibrary.Infraestructure;
using System.Linq;

namespace DigitalLibrary.Controllers;
public class UserController : Controller
{
    //Guarda el contexto para acceder a la base de datos
    private readonly AppDbContext _context;

    // Inyección de dependencias (para que el controlador pueda interacturar con EF
    public UserController(AppDbContext context)
    {
        _context = context;
    }

    
    // Index: lista de usuarios
    // ------------------------------------------------------------
    public IActionResult Index()
    {
        var users = _context.Users.ToList();
        return View(users);
    }

    
    // Create : muestra formulario de creación
    // ------------------------------------------------------------
    public IActionResult Create()
    {
        // Solo retornar la vista del formulario
        return View();
    }
    
    // SaveCreate procesa y guarda el formulario de creación
    public IActionResult SaveCreate(string name, int age = 0, string docNumber = "", string email = "", int celNumber = 0)
    {
        try
        {
            // Validar que el nombre no este basico
            if (string.IsNullOrWhiteSpace(name))
            {
                ViewBag.Error = "El nombre es obligatorio.";
                return View("Create");
            }

            // Crear objeto user
            var user = new User
            {
                Name = name,
                Age = age,
                DocNumber = docNumber,
                Email = email,
                CelNumber = celNumber,
                RegistrationDate = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
            };

            // Guardar en la base de datos
            _context.Users.Add(user);
            _context.SaveChanges();

            //Volver al Index
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Error guardando el usuario: " + ex.Message;
            return View("Create");
        }
    }
    // ------------------------------------------------------------

    
    // Edit: muestra el formulario de editar usuario
    // ------------------------------------------------------------
    public IActionResult Edit(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return RedirectToAction("Index");
        }
        
        return View(user);
    }
    
    // SaveEdit: procesa el formulario de edición
    public IActionResult SaveEdit(int id, string name, int age = 0, string docNumber = "", string email = "", int celNumber = 0)
    {
        try
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                ViewBag.Error = "Usuario no encontrado.";
                return RedirectToAction("Index");
            }

            // Actualizar manualmente los campos permitidos
            user.Name = name;
            user.Age = age;
            user.DocNumber = docNumber;
            user.Email = email;
            user.CelNumber = celNumber;

            // Guardar cambios
            _context.Users.Update(user);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ViewBag.Error = "Error editando el usuario: " + ex.Message;
            return RedirectToAction("Index");
        }
    }
    // ------------------------------------------------------------

    
    // Delete se muestra la vista
    // ------------------------------------------------------------
    public IActionResult Delete(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null)
        {
            return RedirectToAction("Index");
        }
        return View(user);
    }
    
    // ConfirmDelete
    public IActionResult ConfirmDelete(int id)
    {
        var user = _context.Users.Find(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        return RedirectToAction("Index");
    }
    // ------------------------------------------------------------
}

