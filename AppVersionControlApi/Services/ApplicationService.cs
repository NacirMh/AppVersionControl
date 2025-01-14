using AppVersionControlApi.Entities;
using AppVersionControlApi.Enums;
using AppVersionControlApi.Interfaces;
using AppVersionControlApi.Repositories;

namespace AppVersionControlApi.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IVersionRepository _versionRepository;

        public ApplicationService(IApplicationRepository applicationRepository , IVersionRepository versionRepository)
        {
           _applicationRepository = applicationRepository;
           _versionRepository = versionRepository;
        }
        public Application CreateApplication(Application application)
        {
            var createdApplication = _applicationRepository.CreateApplication(application);
            return createdApplication;
        }
        

        public bool DeleteApplication(int id)
        {
            return _applicationRepository.DeleteApplication(id);
        }

        public IEnumerable<Application> GetAllApplications()
        {
            return _applicationRepository.GetAllApplications();
        }

        public Application? GetApplicationById(int id)
        {
            return _applicationRepository.GetApplicationById(id);
        }

        public IEnumerable<Application> GetApplicationsByUserId(string UserId)
        {
             return _applicationRepository.GetApplicationsByUserId(UserId);
        }
        public bool AssignApplicationToUser(string userId, int applicationId)
        {
            if(_applicationRepository.AssignApplicationToUser(userId, applicationId))
            {
                return true;
            }
            return false;

        }
        public bool UpdateApplicationVersion(int applicationId, int versionId)
        {
           return _applicationRepository.UpdateApplicationVersion(applicationId, versionId);
        }
    }
}
