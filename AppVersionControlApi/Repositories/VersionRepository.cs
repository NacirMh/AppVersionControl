using AppVersionControlApi.Data;
using AppVersionControlApi.Entities;
using AppVersionControlApi.Interfaces;
using Version = AppVersionControlApi.Entities.Version;

namespace AppVersionControlApi.Repositories
{
    public class VersionRepository : IVersionRepository
    {
        private readonly AppDbContext _dbContext;
        public VersionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Version AddVersion(Version version)
        {
            var addedVersion = _dbContext.Versions.Add(version);
            _dbContext.SaveChanges();
            return addedVersion.Entity;
        }

        public bool DeleteVersion(int id)
        {
            var existingVersion = GetVersionById(id);
            if (existingVersion != null)
            {
                existingVersion.Application.CurrentVersionId = null;
                _dbContext.Versions.Remove(existingVersion);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Version? GetVersionById(int id)
        {
            var existingVersion = _dbContext.Versions.FirstOrDefault(x => x.Id == id);
            return existingVersion;
        }

        public IEnumerable<Version> GetVersionsByAppId(int id)
        {
            var versions = _dbContext.Versions.Where(x => x.ApplicationId == id);
            return versions;
        }

        public Version UpdateVersion(Version version)
        {
            var existingVersion = GetVersionById(version.Id);
            if (existingVersion != null)
            {
                existingVersion.VersionNumber = version.VersionNumber;
                existingVersion.Description = version.Description;
                existingVersion.Severity = version.Severity;
            }
            _dbContext.SaveChanges();

            return existingVersion;
        }
    }
}
