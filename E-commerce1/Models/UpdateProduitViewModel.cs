﻿using System.ComponentModel.DataAnnotations;

namespace E_commerce1.Models
{
    public class UpdateProduitViewModel
    {
        [Key]
        public int idProduit { get; set; }
        public string nomProduit { get; set; }
        public decimal prix { get; set; }
        public string reference { get; set; }
        public string description { get; set; }
        //public Image image;

        //public int idUtilisateur { get; set; }

        //public int idCategorie { get; set; }
        //public int idStock { get; set; } 
    }
}
