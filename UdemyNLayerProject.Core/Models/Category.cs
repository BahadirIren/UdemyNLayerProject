using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace UdemyNLayerProject.Core.Models
{
    public class Category
    {
        // Constructor
        public Category()
        {
            Products = new Collection<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        // her kategori birden fazla urune sahip olabilir
        public ICollection<Product> Products { get; set; }

    }
}
