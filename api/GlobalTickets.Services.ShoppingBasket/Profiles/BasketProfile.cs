using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTickets.Services.ShoppingBasket.Profiles
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Models.BasketForCreation, Entities.BasketEntity>();
            CreateMap<Models.Basket, Entities.BasketEntity>().ReverseMap().ForMember(dest => dest.NumberOfItems, src => src.MapFrom(b => b.BasketLines.Count));
        }
    }
}
