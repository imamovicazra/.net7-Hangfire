using Hangfire.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Model.Interfaces
{
    public interface IDriverService
    {
        public Task<DriverDTO> Create(DriverDTO model);
        public Task<DriverDTO> GetDriverAsync(Guid id);
        public Task DeleteDriverAsync(Guid id)
    }
}
