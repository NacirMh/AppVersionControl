
using AppVersionControlApi.Dtos.Application;
using AppVersionControlApi.Entities;

namespace AppVersionControlApi.Mappers
{
    public static class ApplicationMapper
    {
        //extension method
        public static Application ToApplicationFromCreateApplicationDTO(this CreateApplicationDTO dto)
        {
            return new Application
            {
                Name = dto.Name, 
                Description = dto.Description,  
            };

        }
       

        public static ApplicationDTO ToApplicationDTO(this Application app)
        {
            return new ApplicationDTO
            {
                Id = app.Id,
                Name = app.Name,
                Description= app.Description,
                CurrentVersionId = app.CurrentVersionId,
                Versions = app.Versions.Select(x => x.ToVersionDTO()),
            };


        }
    }
}
