using Microsoft.AspNetCore.Mvc;
using DigitalLibrary.Models;
using DigitalLibrary.Infraestructure;
using System.Linq;

namespace DigitalLibrary.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // Mostrar todos los usuarios
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }

        // Formulario para crear usuario
        public IActionResult Create()
        {
            return View();
        }

        // Acción para guardar usuario (sin atributos [HttpPost])
        public IActionResult SaveNew()
        {
            try
            {
                // Obtener los datos manualmente desde el formulario
                var id = int.Parse(Request.Form["Id"]);
                var name = Request.Form["Name"];
                var age = int.Parse(Request.Form["Age"]);
                var docNumber = Request.Form["DocNumber"];
                var email = Request.Form["Email"];
                var celNumber = int.Parse(Request.Form["CelNumber"]);

                // Validar documento duplicado
                if (_context.Users.Any(u => u.DocNumber == docNumber))
                {
                    ViewBag.Error = "El documento ya está registrado.";
                    return View("Create");
                }

                var registrationDate = DateOnly.FromDateTime(DateTime.Now);
                var user = new User(id, name, age, docNumber, email, celNumber, registrationDate);

                _context.Users.Add(user);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error al registrar el usuario. Verifique los datos.";
                return View("Create");
            }
        }

        // Formulario para editar
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // Guardar cambios de edición (sin [HttpPost])
        public IActionResult SaveEdit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            try
            {
                var name = Request.Form["Name"];
                var age = int.Parse(Request.Form["Age"]);
                var docNumber = Request.Form["DocNumber"];
                var email = Request.Form["Email"];
                var celNumber = int.Parse(Request.Form["CelNumber"]);

                if (_context.Users.Any(u => u.DocNumber == docNumber && u.ID != id))
                {
                    ViewBag.Error = "Ya existe otro usuario con ese documento.";
                    return View("Edit", user);
                }

                // Actualizar manualmente
                user.Name = name;
                user.Age = age;
                user.DocNumber = docNumber;
                user.Email = email;
                user.CelNumber = celNumber;

                _context.Users.Update(user);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Error = "Error al editar el usuario.";
                return View("Edit", user);
            }
        }

        // Confirmación de eliminación
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // Acción de eliminar (sin [HttpPost])
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
    }
}
