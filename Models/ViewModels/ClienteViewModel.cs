using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab2.Models.ViewModels
{
    public class ClienteViewModel
    {
        public int id_cli { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
        public string nombre_cli { get; set; }

        [Required]
        [Display(Name = "Cedula")]
        [StringLength(10, ErrorMessage = "La cedula no puede tener mas de 10 caracteres")]
        public string cedula_cli { get; set; }


        [Required]
        [Display(Name = "Correo")]
        [EmailAddress(ErrorMessage = "Correo invalido")]
        [StringLength(50, ErrorMessage = "El correo no puede tener mas de 50 caracteres")]
        public string correo { get; set; }

        [Required]
        [Display(Name = "FechaNacimiento")]
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
    }
}