using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;
using CleanArch.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetById(int? id)
        {
            return await _context.Products.FindAsync(id);

        }

        void IProductRepository.Add(Product product)
        {
            throw new NotImplementedException();
        }

        Task<Product> IProductRepository.GetById(int? id)
        {
            throw new NotImplementedException();
        }

        void IProductRepository.Remove(Product product)
        {
            throw new NotImplementedException();
        }

        void IProductRepository.Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
