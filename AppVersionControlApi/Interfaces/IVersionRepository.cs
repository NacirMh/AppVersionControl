using Version = AppVersionControlApi.Entities.Version;

namespace AppVersionControlApi.Interfaces
{
    public interface IVersionRepository
    {
        public Version GetVersionById(int versionId);

        public IEnumerable<Version> GetVersionsByAppId(int appId);

        public Version AddVersion(Version version);

        public Version UpdateVersion(Version version);

        public bool DeleteVersion(int id);

    }
}
