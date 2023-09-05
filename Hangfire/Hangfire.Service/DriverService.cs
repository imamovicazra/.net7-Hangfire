using AutoMapper;
using Hangfire.Database;
using Hangfire.Model;
using Hangfire.Model.DTOs;
using Hangfire.Model.Interfaces;

namespace Hangfire.Service
{
    public class DriverService: IDriverService
    {
        private readonly IMapper _mapper;
        private readonly HangfireContext _dbContext;

        public DriverService(HangfireContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        public async Task<DriverDTO> Create(DriverDTO model)
        {
            var entity = _mapper.Map<Driver>(model);

            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<DriverDTO>(entity);
        }
    }

}
