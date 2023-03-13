using System;
using ITBees.BaseServices.Platforms.Interfaces;

namespace ITBees.BaseServices.Platforms
{
    public class CurrentDateTimeService : ICurrentDateTimeService
    {
        public DateTime GetCurrentDate()
        {
            DateTime currentDateTime;
            if (OperatingSystem.IsLinux())
            {
                currentDateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Europe/Warsaw").DateTime;
            }
            else
            {
                currentDateTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTimeOffset.UtcNow, "Central European Standard Time").DateTime;
            }

            return currentDateTime;
        }
    }
}