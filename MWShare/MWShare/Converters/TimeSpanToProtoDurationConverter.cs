using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace MWShare.Converters
{
    public class TimeSpanToProtoDurationConverter : ITypeConverter<TimeSpan, Duration>
    {
        public Duration Convert(TimeSpan source, Duration destination, ResolutionContext context)
        {
            return Duration.FromTimeSpan(source);
        }
    }
}
