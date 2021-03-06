﻿using AutoMapper;
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
                cfg.CreateMap<NewStudioViewModel, Studio>().MaxDepth(2);
                cfg.CreateMap<User, UserViewModel>().MaxDepth(2);
                cfg.CreateMap<UserViewModel, User>().MaxDepth(2);
            });
        }
    }
}