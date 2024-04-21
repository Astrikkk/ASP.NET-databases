using ASPNET_databases.Data.Entities;
using ASPNET_databases.Models;
using AutoMapper;


namespace ASPNET_databases
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<TankFormModel, Tank>().ReverseMap();
            CreateMap<Tank, TankCartModel>();
        }
    }
}
