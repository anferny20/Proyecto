using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Proyecto.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        [Display(Name="Identificador")]
        public int CategoryId { get; set; }

        [Display(Name = "Categoria")]
        public string CategoryName { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }
        public byte[] Picture { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
