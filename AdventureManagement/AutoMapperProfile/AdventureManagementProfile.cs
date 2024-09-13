using AdventureManagement.API.Entities;
using AdventureManagement.API.ViewModel.AdventureViewModel;
using AdventureManagement.API.ViewModel.GuideViewModel;
using AdventureManagement.API.ViewModel.OrganismViewModel;
using AdventureManagement.API.ViewModel.Participant;
using AutoMapper;

namespace AdventureManagement.API.AutoMapperProfile
{
    public class AdventureManagementProfile : Profile
    {
        public AdventureManagementProfile()
        {
            CreateMap<Participant, ParticipantVM>()
                .ForMember(dest => dest.AdventureCount, opt => opt.MapFrom(src => src.ParticipantInteractions.Count));

            CreateMap<Guide, GuideVM>()
                .ForMember(dest => dest.AdventureCount, opt => opt.MapFrom(src => src.Adventures.Count));

            CreateMap<Organism, OrganismVM>()
                .ForMember(dest => dest.AdventureCount, opt => opt.MapFrom(src => src.AdventureOrganisms.Count))
                .ForMember(dest => dest.Adventures, opt => opt.MapFrom(src => src.AdventureOrganisms.Select(ao => ao.Adventure)));

            CreateMap<Adventure, AdventureVM>()
                .ForMember(dest => dest.ParticipantCount, opt => opt.MapFrom(src => src.ParticipantInteractions.Count))
                .ForMember(dest => dest.Guide, opt => opt.MapFrom(src => src.Guide))
                .ForMember(dest => dest.Organisms, opt => opt.MapFrom(src => src.AdventureOrganisms.Select(ao => ao.Organism)));

            CreateMap<CreateAdventureVM, Adventure>()
                .ForMember(dest => dest.AdventureOrganisms, opt => opt.MapFrom(src => src.OrganismIds.Select(id => new AdventureOrganism { OrganismId = id })));

            CreateMap<UpdateAdventureVM, Adventure>()
                .ForMember(dest => dest.AdventureOrganisms, opt => opt.MapFrom(src => src.OrganismIds.Select(id => new AdventureOrganism { OrganismId = id })));
        }
    }
}
