using AutoMapper;

namespace Projecto.Infrastructure.AutoMapper
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}