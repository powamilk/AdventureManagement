using AdventureManagement.API.Entities;
using AdventureManagement.API.ViewModel.AdventureVM;
using AdventureManagement.API.ViewModel.GuideViewModel;
using AdventureManagement.API.ViewModel.OrganismVM;
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

            CreateMap<Organism, OrganismVM>();

            CreateMap<Adventure, AdventureVM>()
                .ForMember(dest => dest.ParticipantCount, opt => opt.MapFrom(src => src.ParticipantInteractions.Count))
                .ForMember(dest => dest.Guide, opt => opt.MapFrom(src => src.Guide));
        }
    }


}
