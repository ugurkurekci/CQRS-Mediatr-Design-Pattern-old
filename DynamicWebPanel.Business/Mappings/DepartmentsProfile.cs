using AutoMapper;
using DynamicWebPanel.Business.DTOs.Departments;
using DynamicWebPanel.Business.Utilities.Constans;
using DynamicWebPanel.Entity;

namespace DynamicWebPanel.Business.Mappings;

public class DepartmentsProfile : Profile
{
    public DepartmentsProfile()
    {
        CreateMap<DepartmentsUpdateDto, DepartmentsModel>();

        CreateMap<DepartmentsCreateDto, DepartmentsModel>()
            .ForMember(destination => destination.DepartmentsName,
                 source => source.MapFrom(_ => _.DepartmentsName))
            .ForMember(destination => destination.CreateDate,
                 source => source.MapFrom(i => DateTime.Now));

        CreateMap<DepartmentsModel, DepartmentsListDto>()
             .ForMember(destination => destination.CreateDate, source => source.MapFrom(s => s.CreateDate.ToString(DateFormatConstans.BASICDATEFORMAT)));


    }
}