namespace ProyectoECI.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Status : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} es requerido")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [Display(Name = "Estado")]
        public string Name { get; set; }
    }
}
