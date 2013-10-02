using AutoMapper;
using BoardGameManager.Domain.Entities;
using BoardGameManager.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BoardGameManager.Web.MapperProfiles
{
    public class DomainToViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<BoardGame, BoardGameViewModel>();
        }
    }
}