using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dinnerLight.Application.Common.Interfaces.Services;

namespace dinnerLight.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}