using AutoMapper;
using DvdShop.Models.Entities;
using DvdShop.Models.ViewModel;

namespace DvdShop.Mapping
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Studio, NewStudioViewModel>().MaxDepth(2);
            });
        }
    }
}