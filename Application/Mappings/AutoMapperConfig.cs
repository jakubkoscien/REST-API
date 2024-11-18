using Application.DTO;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<CreatePostDTO, Post>();
                cfg.CreateMap<UpdatePostDTO, Post>();
                cfg.CreateMap<DeletePostDTO, Post>();
            })
            .CreateMapper();
    }
}

