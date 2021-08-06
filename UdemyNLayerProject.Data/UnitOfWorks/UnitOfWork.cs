using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdemyNLayerProject.Core.Repositories;
using UdemyNLayerProject.Core.UnitOfWorks;
using UdemyNLayerProject.Data.Repositories;

namespace UdemyNLayerProject.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        // _productRepository varsa al eger null ise yeni ProductRepository olustur
        // ?? isareti ile null kontrolu yapiyoruz
        public IProductRepository Products =>
            _productRepository ??= new ProductRepository(_context);

        // _categoryRepository varsa al eger null ise yeni CategoryRepository olustur
        public ICategoryRepository Categories =>
            _categoryRepository ??= new CategoryRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
