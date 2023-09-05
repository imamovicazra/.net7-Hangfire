using AutoMapper;
using Hangfire.Model;
using Hangfire.Model.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hangfire.API.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Driver, DriverDTO>().ReverseMap();
        }
    }
}
