using System;

namespace VKMSmalta.Admin.Models.Dto
{
    public class PingResponseDto
    {
        public string ServiceVersion { get; set; }
        public TimeSpan Uptime { get; set; }

        public override string ToString()
        {
            return $"{nameof(ServiceVersion)}: {ServiceVersion}, {nameof(Uptime)}: {Uptime}";
        }
    }
}