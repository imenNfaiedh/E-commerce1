using System.ComponentModel.DataAnnotations;

namespace E_commerce1.Models.Domain
{
    public class Categorie
    {

        [Key]
        public int idCategorie {  get; set; }
        public string nomCategorie { get; set; }
    }
}
