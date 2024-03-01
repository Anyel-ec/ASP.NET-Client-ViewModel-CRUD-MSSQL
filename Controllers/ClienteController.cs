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
    }
}