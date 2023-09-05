using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Model.DTOs
{
    public class DriverDTO
    {
        public string Name { get; set; }
        public int DriveNumber { get; set; }
        public int Status { get; set; }
    }
}
