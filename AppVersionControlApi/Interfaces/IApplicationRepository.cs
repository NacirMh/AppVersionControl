using AppVersionControlApi.Entities;

namespace AppVersionControlApi.Interfaces
{
    public interface IApplicationRepository
    {

        public IEnumerable<Application> GetAllApplications();
        public IEnumerable<Application> GetApplicationsByUserId(string UserId);
        public Application? GetApplicationById(int id);
        public bool DeleteApplication(int id);
        public Application CreateApplication(Application application);
        public bool UpdateApplicationVersion(int applicationId, int versionId);
        public bool AssignApplicationToUser(string userId, int applicationId);
    }
}
