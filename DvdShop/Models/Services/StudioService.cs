using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DvdShop.Models.Entities;
using DvdShop.Models.Repositories;

namespace DvdShop.Models.Services
{
    public interface IStudioService
    {
        IEnumerable<Studio> GetAllStudios();
        Studio GetStudioById(int id);
        Studio GetStudioByCode(string code);
        void Add(Studio studio);
        void Update(Studio studio);
        void Delete(Studio studio);
       
    }
    public class StudioService : IStudioService
    {
        private readonly IStudioRepository _studioRepository;
        private readonly IUnitOfWork _unitOfWork;
        public StudioService(IStudioRepository studioRepository,IUnitOfWork unitOfWork)
        {
            this._studioRepository = studioRepository;
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Studio> GetAllStudios()
        {
          return  _studioRepository.GetAll();
        }

        public Studio GetStudioById(int id)
        {
            return _studioRepository.GetById(id);
        }

        public Studio GetStudioByCode(string code)
        {
            return _studioRepository.GetByName(code);
        }

        public void Add(Studio studio)
        {
            _studioRepository.Add(studio);
          
        }

        public void Update(Studio studio)
        {
            _studioRepository.Update(studio);
            
        }

        public void Delete(Studio studio)
        {
            _studioRepository.Delete(studio);
            
        }
        
    }
}