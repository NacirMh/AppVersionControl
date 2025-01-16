using AppVersionControlApi.Data;
using AppVersionControlApi.Entities;
using AppVersionControlApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppVersionControlApi.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _dbContext;
        public ApplicationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Application> GetAllApplications()
        {
            return _dbContext.Applications;
        }

        
        public IEnumerable<Application> GetApplicationsByUserId(string UserId)
        {
            var applications = _dbContext.Applications.Where(x => x.Users.Any(y => y.UserId == UserId));
            return applications;
        }

        public Application? GetApplicationById(int id)
        {
            var application = _dbContext.Applications.FirstOrDefault(x => x.Id == id);
            return application;
        }

        public Application CreateApplication(Application application)
        {
            var addedApp = _dbContext.Applications.Add(application);
            _dbContext.SaveChanges();
            return addedApp.Entity;
        }

        public bool AssignApplicationToUser(string userId, int applicationId)
        {
            var app = GetApplicationById(applicationId);
            var alreadyAssigned = _dbContext.UserApplications.FirstOrDefault(x => x.ApplicationId == applicationId && x.UserId == userId);
            if (app != null && alreadyAssigned == null)
            {
                var UserApplication = new UserApplication
                {
                    ApplicationId = applicationId,
                    UserId = userId
                };
                _dbContext.UserApplications.Add(UserApplication);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }


        public bool DeleteApplication(int id)
        {
            var application = GetApplicationById(id);
            if (application != null)
            {
                _dbContext.Applications.Remove(application);
                _dbContext.SaveChanges();

                return true;
            }
            return false;
        }

        public bool UpdateApplicationVersion(int applicationId, int versionId)
        {
            var existingApplication = GetApplicationById(applicationId);
            var existingVersion = _dbContext.Versions.FirstOrDefault(x => x.Id == versionId);

            if (existingApplication != null && existingVersion.ApplicationId == applicationId)
            {
                existingApplication.CurrentVersionId = versionId;
                _dbContext.SaveChanges();
                return true;
            }
            return false;

        }

        public Application? UpdateApplication(Application application)
        {
            var existingApp = GetApplicationById(application.Id);
            if (existingApp != null)
            {
                existingApp.Name = application.Name;
                existingApp.Description = application.Description;
                _dbContext.SaveChanges();
            }
            return existingApp;
        }

        public bool RevokeApplicationFromUser(string userId, int applicationId)
        {
            var app = GetApplicationById(applicationId);
            var alreadyAssigned = _dbContext.UserApplications.FirstOrDefault(x => x.ApplicationId == applicationId && x.UserId == userId);
            if (app != null && alreadyAssigned != null)
            {
                _dbContext.UserApplications.Remove(alreadyAssigned);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
