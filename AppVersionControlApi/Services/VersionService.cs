using AppVersionControlApi.Interfaces;
using Version = AppVersionControlApi.Entities.Version;

namespace AppVersionControlApi.Services
{
    public class VersionService : IVersionService
    {
        private readonly IVersionRepository _versionRepository;
        public VersionService(IVersionRepository versionRepository)
        {
            _versionRepository = versionRepository;
        }
        public Version AddVersion(Version version)
        {
            return _versionRepository.AddVersion(version);
        }

        public bool DeleteVersion(int id)
        {
            return _versionRepository.DeleteVersion(id);
        }

        public Version GetVersionById(int versionId)
        {
            return _versionRepository.GetVersionById(versionId);
        }

        public IEnumerable<Version> GetVersionsByAppId(int appId)
        {
            return _versionRepository.GetVersionsByAppId(appId);
        }

        public Version UpdateVersion(Version version)
        {
            return _versionRepository.UpdateVersion(version);
        }
    }
}
