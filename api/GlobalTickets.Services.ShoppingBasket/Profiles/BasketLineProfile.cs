using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTickets.Services.ShoppingBasket.Profiles
{
    public class BasketLineProfile : Profile
    {
        public BasketLineProfile()
        {
            CreateMap<Models.BasketLineForCreation, Entities.BasketLineEntity>();
            CreateMap<Models.BasketLineForUpdate, Entities.BasketLineEntity>();
            CreateMap<Entities.BasketLineEntity, Models.BasketLine>().ReverseMap();

        }
    }
}
