using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;

namespace DvdShop.Models.Services
{
    public interface IProductService
    {
        Product GetProductById(int id);
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetAllProductsByStudio(string studio);
        IEnumerable<Product> GetAllProductsByDate(DateTime date);
        IEnumerable<Product> GetAllProductsWithCondition(DateTime date,int studioId);
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);

    }
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProducRepository _producRepository;

        public ProductService(IUnitOfWork unitOfWork,IProducRepository producRepository)
        {
            _unitOfWork = unitOfWork;
            _producRepository = producRepository;
        }

        public Product GetProductById(int id)
        {
            return _producRepository.GetById(id);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _producRepository.GetAll();
        }

        public IEnumerable<Product> GetAllProductsByStudio(string studio)
        {
            return _producRepository.GetManyCondition(x => x.Studio.StudioCode == studio);
        }

        public IEnumerable<Product> GetAllProductsByDate(DateTime date)
        {
            return _producRepository.GetManyCondition(x => x.ReceivedDate == date);
        }

        public IEnumerable<Product> GetAllProductsWithCondition(DateTime date, int studioId)
        {
            return _producRepository.GetManyCondition(x => x.ReceivedDate == date || x.StudioId==studioId);
        }

        public void Add(Product product)
        {
            _producRepository.Add(product);
        }

        public void Update(Product product)
        {
           _producRepository.Update(product);
        }

        public void Delete(Product product)
        {
           _producRepository.Delete(product);
        }
    }
}