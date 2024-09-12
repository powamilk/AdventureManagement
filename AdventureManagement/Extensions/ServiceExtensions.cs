using AdventureManagement.API.AutoMapperProfile;
using AdventureManagement.API.Service.Implement;
using AdventureManagement.API.Service.Interface;
using AdventureManagement.API.Validator;
using AdventureManagement.API.ViewModel.Participant;
using FluentValidation;

namespace AdventureManagement.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<IParticipantService, ParticipantService>();
            services.AddScoped<IGuideService, GuideService>();
            services.AddScoped<IOrganismService, OrganismService>();
            services.AddScoped<IAdventureService, AdventureService>();
            return services;    
        }
        public static IServiceCollection AddFluentValidator(this IServiceCollection services)
        {
            services.AddScoped<IValidator<ParticipantCreateVM>, ParticipantCreateValidator>();
            services.AddScoped<IValidator<ParticipantUpdateVM>, ParticipantUpdateValidator>();
            
            return services;
        }

        public static IServiceCollection AddMapperProfile(this IServiceCollection services)
        {
            services.AddAutoMapper(c =>
            {
                c.AddProfile(new ParticipantProfile());
                c.AddProfile(new AdventureManagementProfile());
            });
            return services;    
        }
    }
}
