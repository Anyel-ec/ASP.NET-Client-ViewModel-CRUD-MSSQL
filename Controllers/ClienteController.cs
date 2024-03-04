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
            // conexion a la base de datos
            List<ListClienteViewModel> listaClientes;

            using (lab2Entities db = new lab2Entities())
            {
                listaClientes = (from c in db.cliente
                                 select new ListClienteViewModel
                                 {
                                     id_cli = c.id_cli,
                                     nombre_cli = c.nombre_cli,
                                     cedula_cli = c.cedula_cli,
                                     correo = c.correo
                                 }).ToList();
            }

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
                // valida los data Annotations
                if (ModelState.IsValid)
                {
                    // si todo es valido se procede a guardar
                    using (lab2Entities db = new lab2Entities())
                    {
                        var cliente = new cliente();
                        cliente.nombre_cli = clienteViewModel.nombre_cli;
                        cliente.cedula_cli = clienteViewModel.cedula_cli;
                        cliente.correo = clienteViewModel.correo;
                        cliente.fechaNacimiento = clienteViewModel.fechaNacimiento;

                        db.cliente.Add(cliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index");
                }
                return View (clienteViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        ///////////////////////////////////////////////////////////////

        public ActionResult Editar()
        {
            ClienteViewModel clienteViewModel = new ClienteViewModel();
            using (lab2Entities db = new lab2Entities())
            {
                var cliente = db.cliente.Find(1);
                clienteViewModel.nombre_cli = cliente.nombre_cli;
                clienteViewModel.cedula_cli = cliente.cedula_cli;
                clienteViewModel.correo = cliente.correo;
                clienteViewModel.fechaNacimiento = (DateTime)cliente.fechaNacimiento;
                clienteViewModel.id_cli = cliente.id_cli;
            }
            return View (clienteViewModel);




            return View();
        }

        [HttpPost]
        public ActionResult Editar(ClienteViewModel clienteViewModel)
        {
            try
            {
                // valida los data Annotations
                if (ModelState.IsValid)
                {
                    // si todo es valido se procede a guardar
                    using (lab2Entities db = new lab2Entities())
                    {
                        var cliente = new cliente();
                        cliente.nombre_cli = clienteViewModel.nombre_cli;
                        cliente.cedula_cli = clienteViewModel.cedula_cli;
                        cliente.correo = clienteViewModel.correo;
                        cliente.fechaNacimiento = clienteViewModel.fechaNacimiento;

                        db.cliente.Add(cliente);
                        db.SaveChanges();
                    }
                    return Redirect("~/Cliente/Index");
                }
                return View(clienteViewModel);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}