using AutoMapper;
using MWShare.Converters;
using Google.Protobuf.WellKnownTypes;

namespace MWShare.Mappers
{
    public static class MapperExtensions
    {
        public static void InitClassToProtoDefaultConfigs(this IProfileExpression profileExpression)
        {
            profileExpression.AllowNullCollections = true;
            profileExpression.AllowNullDestinationValues = true;
            profileExpression.CreateMap<DateTime, Timestamp>().ConvertUsing(new DateTimeToProtoTimestampConverter());
        }
        public static void InitProtoToClassDefaultConfigs(this IProfileExpression profileExpression)
        {
            profileExpression.AllowNullCollections = true;
            profileExpression.AllowNullDestinationValues = true;
            profileExpression.CreateMap<Timestamp, DateTime>().ConvertUsing(new DateTimeFromProtoTimestampConverter());
        }
        public static void CreateMapCustom<TSource, TDestination>(this IProfileExpression profileExpression)
        {
            profileExpression.CreateMap<TSource, TDestination>().ForAllMembers(options =>
            {
                options.Condition((src, dest, srcMember) => srcMember != null);
            });
        }

        #region 2024-02-26 Chỉnh sửa lại để ngắn gọn hơn

        public static void InitDefaultConfigs(this IProfileExpression profileExpression)
        {
            profileExpression.AllowNullCollections = true;
            profileExpression.AllowNullDestinationValues = true;

            profileExpression.CreateMap<Timestamp, DateTime>().ConvertUsing(new DateTimeFromProtoTimestampConverter());
            profileExpression.CreateMap<DateTime, Timestamp>().ConvertUsing(new DateTimeToProtoTimestampConverter());
        }

        public static void CreateBidirectionalMap<TSource, TDestination>(this IProfileExpression profileExpression)
        {
            profileExpression.CreateMap<TSource, TDestination>().ForAllMembers(options =>
            {
                options.Condition((src, dest, srcMember) => srcMember != null);
            });

            profileExpression.CreateMap<TDestination, TSource>().ForAllMembers(options =>
            {
                options.Condition((src, dest, srcMember) => srcMember != null);
            });
        }

        #endregion
    }
}
