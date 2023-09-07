using AutoMapper;
using Hangfire.Database;
using Hangfire.Model;
using Hangfire.Model.DTOs;
using Hangfire.Model.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

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

        public async Task<DriverDTO> GetDriverAsync(Guid id)
        {
            var entity=await _dbContext.Drivers.Where(s => s.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<DriverDTO>(entity);
        }
        public async Task DeleteDriverAsync(Guid id)
        {
            var entity = await _dbContext.Drivers.Where(s => s.Id == id).FirstOrDefaultAsync();
            if(entity != null && entity.Status!=0)
            {
                entity.Status = 0;
                _dbContext.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
