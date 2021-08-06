using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyNLayerProject.Core.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int Stock { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public bool IsDeleted { get; set; }

        public string InnerBarcode { get; set; }

        // Category sinifina referans veriyoruz
        // Entity Framework bu Category uzerinden inherit kullanarak tracking yapacak,
        // degisiklikleri izleyecek bu yuzden virtual kullandik
        public virtual Category Category { get; set; } 

    }
}
