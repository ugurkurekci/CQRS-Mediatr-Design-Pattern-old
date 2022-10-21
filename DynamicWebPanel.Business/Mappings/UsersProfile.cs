using AutoMapper;
using DynamicWebPanel.Business.DTOs.Users;
using DynamicWebPanel.Business.Utilities.Constans;
using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Business.Mappings;

public class UsersProfile : Profile
{
    public UsersProfile()
    {
        CreateMap<UsersUpdateDto, UsersModel>();

        CreateMap<UsersCreateDto, UsersModel>()
            .ForMember(destination => destination.CreateDate,
                 source => source.MapFrom(i => DateTime.Now));

        CreateMap<UsersModel, UsersListDto>()
             .ForMember(destination => destination.ID, source => source.MapFrom(s => s.ID))
             .ForMember(destination => destination.DepartmentsName, source => source.MapFrom(s => s.DepartmentsModel.DepartmentsName))
             .ForMember(destination => destination.CreateDate, source => source.MapFrom(s => s.CreateDate.ToString(DateFormatConstans.BASICDATEFORMAT)))
             .ForMember(destination => destination.DateOfBirth, source => source.MapFrom(s => s.CreateDate.ToString(DateFormatConstans.BASICDATEFORMAT)));
    }
}