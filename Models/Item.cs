using System.ComponentModel.DataAnnotations;

namespace ProyectoNuevo.Models
{
    public class Item
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(60, ErrorMessage = "El nombre no puede tener más de 60 caracteres")]
        public string name { get; set; }
        public string type { get; set; }
        [Range (-100, 100, ErrorMessage = "El precio debe estar entre -100 y 100")]
        public int STR { get; set; }
        [Range (-100, 100, ErrorMessage = "El precio debe estar entre -100 y 100")]
        public int AGI { get; set; }
        [Range (-100, 100, ErrorMessage = "El precio debe estar entre -100 y 100")]
        public int INTE { get; set; }
        [Range (-100, 100, ErrorMessage = "El precio debe estar entre -100 y 100")]
        public int MND { get; set; }
        [Range (-100, 100, ErrorMessage = "El precio debe estar entre -100 y 100")]

        public int VIT { get; set; }
       
    }
}