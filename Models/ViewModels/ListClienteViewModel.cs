using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Models.ViewModels
{
    public class ListClienteViewModel
    {
        public int id_cli { get; set; }
        public string nombre_cli { get; set; }
        public string cedula_cli { get; set; }
        public string correo { get; set; }
        //public Nullable<System.DateTime> fechaNacimiento { get; set; }
    }
}