using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Models;
using Lab2.Models.ViewModels;
namespace Lab2.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            // lista de clientes
            List<ListClienteViewModel> listaClientes;
            // conexion a la base de datos 

            using (lab2Entities db = new lab2Entities())
            {
                // almacena la lista de clientes
                listaClientes = (from c in db.cliente
                                 select new ListClienteViewModel
                                 {
                                     id_cli = c.id_cli,
                                     nombre_cli = c.nombre_cli,
                                     cedula_cli = c.cedula_cli,
                                     correo = c.correo
                                 }).ToList(); // convierte a lista
            }
            // retorna la lista de clientes by Anyel EC
            return View(listaClientes);

        }

        public ActionResult Nuevo()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ClienteViewModel clienteViewModel)
        {
            try
            {
                if (ModelState.IsValid)// valida los data Annotations
                {
                    // usar la conexion a la base de datos
                    using (lab2Entities db = new lab2Entities())
                    {
                        // se crea un objeto de tipo cliente
                        var cliente = new cliente();
                        // se asignan los valores del cliente
                        cliente.nombre_cli = clienteViewModel.nombre_cli;
                        cliente.cedula_cli = clienteViewModel.cedula_cli;
                        cliente.correo = clienteViewModel.correo;
                        cliente.fechaNacimiento = clienteViewModel.fechaNacimiento;
                        // se agrega el cliente a la tabla cliente
                        db.cliente.Add(cliente);
                        db.SaveChanges(); // se guardan los cambios
                    }
                    return Redirect("~/Cliente/Index"); // redirecciona a la lista de clientes
                }
                return View (clienteViewModel); // retorna la vista con el modelo
            }
            catch (Exception ex) // si hay un error
            {
                throw new Exception(ex.Message); // lanza una excepcion
            }
        }


        ///////////////////////////////////////////////////////////////

        public ActionResult Editar(int id)
        {
            // se crea un objeto de tipo clienteViewModel
            ClienteViewModel clienteViewModel = new ClienteViewModel();
            // se usa la conexion a la base de datos
            using (lab2Entities db = new lab2Entities())
            {
                // se busca el cliente por el id
                var cliente = db.cliente.Find(id);
                // se asignan los valores del cliente al modelo
                clienteViewModel.nombre_cli = cliente.nombre_cli;
                clienteViewModel.cedula_cli = cliente.cedula_cli;
                clienteViewModel.correo = cliente.correo;
                clienteViewModel.fechaNacimiento = (DateTime)cliente.fechaNacimiento;
                clienteViewModel.id_cli = cliente.id_cli;
            }
            // se retorna la vista con el modelo
            return View (clienteViewModel);
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModel clienteViewModel)
        {
            try
            {
                // valida los data Annotations
                if (ModelState.IsValid)
                {
                    // se usa la conexion a la base de datos
                    using (lab2Entities db = new lab2Entities())
                    {
                        // se busca el cliente por el id del modelo clienteViewModel
                        var cliente = db.cliente.Find(clienteViewModel.id_cli);
                        cliente.nombre_cli = clienteViewModel.nombre_cli;
                        cliente.cedula_cli = clienteViewModel.cedula_cli;
                        cliente.correo = clienteViewModel.correo;
                        cliente.fechaNacimiento = clienteViewModel.fechaNacimiento;
                        // se cambia el estado de la entidad
                        db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges(); // se guardan los cambios
                    }
                    // redirecciona a la lista de clientes
                    return Redirect("~/Cliente/Index");
                }
                // retorna la vista con el modelo
                return View(clienteViewModel);
            }
            catch (Exception ex) // si hay un error
            {
                throw new Exception(ex.Message); // lanza una excepcion
            }
        }

        [HttpGet] // metodo para eliminar
        public ActionResult Eliminar(int id) // recibe el id del cliente
        {
            // se crea un objeto de tipo clienteViewModel
            ClienteViewModel clienteViewModel = new ClienteViewModel();
            // se usa la conexion a la base de datos
            using (lab2Entities db = new lab2Entities()) 
            {
                var cliente = db.cliente.Find(id); // se busca el cliente por el id
                db.cliente.Remove(cliente); // se elimina el cliente
                db.SaveChanges(); // se guardan los cambios
            }
            return Redirect("~/Cliente/Index"); // redirecciona a la lista de clientes
        }
        

    }
}