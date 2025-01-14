
using AppVersionControlApi.Dtos.Application;
using AppVersionControlApi.Entities;

namespace AppVersionControlApi.Mappers
{
    public static class ApplicationMapper
    {
        public static Application ToApplicationFromCreateApplicationDTO(this CreateApplicationDTO dto)
        {
            return new Application
            {
                Name = dto.Name,  
            };

        }

        public static ApplicationDTO ToApplicationDTO(this Application app)
        {
            return new ApplicationDTO
            {
                Id = app.Id,
                Name = app.Name,
                CurrentVersionId = app.CurrentVersionId,
                Versions = app.Versions.Select(x => x.ToVersionDTO()),
                
            };


        }
    }
}
