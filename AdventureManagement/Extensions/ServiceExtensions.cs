using AdventureManagement.API.AutoMapperProfile;
using AdventureManagement.API.Service.Implement;
using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.Validator;
using AdventureManagement.API.ViewModel.AdventureViewModel;
using AdventureManagement.API.ViewModel.Participant;
using AdventureManagement.API.ViewModel.ParticipantInteraction;
using FluentValidation;

namespace AdventureManagement.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IAdventureService, AdventureService>();
            services.AddScoped<IOrganismService, OrganismService>();
            services.AddScoped<IGuideService, GuideService>();
            services.AddScoped<IParticipantInteractionService, ParticipantInteractionService>();
            return services;
        }

        public static IServiceCollection AddFluentValidator(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ParticipantCreateVM>, ParticipantCreateValidator>();
            services.AddScoped<IValidator<ParticipantUpdateVM>, ParticipantUpdateValidator>();
            services.AddScoped<IValidator<CreateAdventureVM>, CreateAdventureValidator>();
            services.AddScoped<IValidator<UpdateAdventureVM>, UpdateAdventureValidator>();
            services.AddScoped<IValidator<CreateParticipantInteractionVM>, CreateParticipantInteractionValidator>();
            services.AddScoped<IValidator<UpdateParticipantInteractionVM>, UpdateParticipantInteractionValidator>();
            return services;
        }

        public static IServiceCollection AddMapperProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(c => c.AddProfile(new AdventureManagementProfile()));
            return services;
        }
    }
}
