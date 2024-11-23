using AutoMapper;
using Google.Protobuf.WellKnownTypes;

namespace MWShare.Converters
{
    public class DateTimeToProtoTimestampConverter : ITypeConverter<DateTime, Timestamp>
    {
        public Timestamp Convert(DateTime source, Timestamp destination, ResolutionContext context)
        {
            if (source.Kind == DateTimeKind.Unspecified)
            {
                return Timestamp.FromDateTime((new DateTime(source.Year, source.Month, source.Day, source.Hour, source.Minute, source.Second, source.Second, DateTimeKind.Local)).ToUniversalTime());
            }
            return Timestamp.FromDateTime(source.ToUniversalTime());
        }
    }
}
