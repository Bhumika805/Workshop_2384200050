using AutoMapper;
using ModelLayer.Model;


public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Map Entity to Model
        CreateMap<AddressBookEntity, AddressBookEntry>();

        // Map Model to Entity(for Create/Update)
        CreateMap<AddressBookRequestDTO, AddressBookEntity>();

        CreateMap<AddressBookEntry, AddressBookEntity>().ReverseMap();
    }
}
