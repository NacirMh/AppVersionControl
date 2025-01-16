using AppVersionControlApi.Dtos.Version;
using Version = AppVersionControlApi.Entities.Version;

namespace AppVersionControlApi.Mappers
{
    public static class VersionMapper
    {
        public static Version ToVersionFromCreateVersionDTO(this CreateVersionDTO versionDto)
        {
            return new Version
            {
              Description = versionDto.Description,
              Severity = versionDto.Severity,
              VersionNumber = versionDto.VersionNumber,
              
              ApplicationId = versionDto.ApplicationId,
            };
        }
        public static Version ToVersionFromUpdateVersionDTO(this UpdateVersionDTO versionDto, int id)
        {
            return new Version
            {
                Id = id,
                Description = versionDto.Description,
                Severity = versionDto.Severity,
                VersionNumber = versionDto.VersionNumber,
            };
        }

        public static VersionDTO ToVersionDTO(this Version version)
        {
            return new VersionDTO
            {
                Id = version.Id,
                Description = version.Description,
                ApplicationId = version.ApplicationId,
                Severity = version.Severity,
                UpdateDate = version.UpdateDate,
                VersionNumber = version.VersionNumber,
            };

        }
    }
}
