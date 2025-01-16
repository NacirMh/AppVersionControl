
using AppVersionControlApi.Dtos.Application;
using AppVersionControlApi.Entities;
using KRM_Events_API.Mappers;

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
       
        public static Application ToApplicationFromUpdateDTO(this UpdateApplicationDTO dto , int id)
        {
            return new Application
            {
                Id = id,    
                Name = dto.Name,
                Description = dto.Description
            };
        }

        public static ApplicationDTO ToApplicationDTO(this Application app)
        {
            return new ApplicationDTO
            {
                Id = app.Id,
                Name = app.Name,
                Description = app.Description,
                CurrentVersionId = app.CurrentVersionId,
                Versions = app.Versions.Select(x => x.ToVersionDTO()),
                Users = app.Users.Select(x => x.User.ToUserDetailsFromUser())
            };


        }
    }
}
