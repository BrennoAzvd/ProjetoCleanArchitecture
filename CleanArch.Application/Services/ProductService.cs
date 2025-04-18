﻿using AutoMapper;
using CleanArch.Application.Interfaces;
using CleanArch.Application.ViewModels;
using CleanArch.Domain.Entities;
using CleanArch.Domain.Interfaces;

namespace CleanArch.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            var products = await _productRepository.GetProducts();
            var productsVM = _mapper.Map<IEnumerable<ProductViewModel>>(products);
            return productsVM;
        }

        public async Task<ProductViewModel> GetById(int? id)
        {
            Product product = await _productRepository.GetById(id);
            ProductViewModel productVM = _mapper.Map<ProductViewModel>(product);
            return productVM;
        }

        public void Add(ProductViewModel product)
        {
            Product mapProduct = _mapper.Map<Product>(product);
            _productRepository.Add(mapProduct);
        }

        public async Task Update(ProductViewModel product)
        {
            Product mapProduct = _mapper.Map<Product>(product);
            await _productRepository.Update(mapProduct);
        }

        public void Remove(int Id)
        {
            _productRepository.Remove(Id);
        }

      
    }
}