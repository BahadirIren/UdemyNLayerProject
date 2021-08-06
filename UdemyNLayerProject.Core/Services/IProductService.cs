using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Models;

namespace UdemyNLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);

        // veritabani ile ilgili olmayan metodlari servis icinde yazabiliriz.
        // Bu yuzden service olusturuyoruz. (Repository ile service i ayri yapiyoruz)
        // bool CheckInnerBarcode(Product product);
    }
}
