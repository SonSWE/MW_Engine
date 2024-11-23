using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace MWShare.Converters
{
    public class DateTimeFromProtoTimestampConverter : ITypeConverter<Timestamp, DateTime>
    {
        public DateTime Convert(Timestamp source, DateTime destination, ResolutionContext context)
        {
            return source != null ? source.ToDateTime().ToLocalTime() : DateTime.MinValue;
        }
    }
}
