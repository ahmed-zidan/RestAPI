using AutoMapper;
using Commander.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Profiles
{
    public class CommandsProfile : Profile
    {

        public CommandsProfile()
        {
            CreateMap<Command, CommandsModel>().ReverseMap();
            CreateMap<CommandUpdateModel, Command>().ReverseMap();
        }

    }
}
