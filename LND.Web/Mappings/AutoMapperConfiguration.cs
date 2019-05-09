using AutoMapper;
using LND.Model.Models;
using LND.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LND.Web.Mappings
{
    public class AutoMapperConfiguration
    {
      
      
        //var config = new MapperConfiguration(cfg =>
        //{
        //    cfg.CreateMap<Post, PostViewModel>();
        //});

        //IMapper mapper = config.CreateMapper();
        //var source = new Post();
        //var dest = mapper.Map<Post, PostViewModel>(source);
    


    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostViewModel>();
            CreateMap<PostCategory, PostCategoryViewModel>();
            CreateMap<Tag, TagViewModel>();
            CreateMap<ProductCategory, ProductCategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductTag, ProductTagViewModel>();
            CreateMap<ContactDetail, ContactDetailViewModel>();
        }
    }
}