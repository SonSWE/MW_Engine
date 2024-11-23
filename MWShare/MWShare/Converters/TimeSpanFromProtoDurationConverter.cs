using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace MWShare.Converters
{
    public class TimeSpanFromProtoDurationConverter : ITypeConverter<Duration, TimeSpan>
    {
        public TimeSpan Convert(Duration source, TimeSpan destination, ResolutionContext context)
        {
            return source?.ToTimeSpan() ?? TimeSpan.Zero;
        }
    }
}
