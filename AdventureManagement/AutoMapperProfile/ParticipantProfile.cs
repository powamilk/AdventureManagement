using AdventureManagement.API.Entities;
using AdventureManagement.API.ViewModel.Participant;
using AutoMapper;

namespace AdventureManagement.API.AutoMapperProfile
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<Participant, ParticipantVM>()
                .ForMember(dest => dest.AdventureCount, opt => opt.MapFrom(src => src.ParticipantInteractions.Count));
        }
    }
}
