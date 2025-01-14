

using AppVersionControlApi.Dtos.Account;
using AppVersionControlApi.Entities;

namespace KRM_Events_API.Mappers
{
    public static class AccountMapper
    {

        public static Admin ToAdminFromRegisterDTO(this RegisterDTO userdto)
        {
            return new Admin
            {
                FirstName = userdto.FirstName,
                LastName = userdto.LastName,
                City = userdto.City,
                Email = userdto.EmailAddress,
                UserName = userdto.UserName,
                PhoneNumber = userdto.PhoneNumber,

            };
        }
        public static User ToUserFromRegisterDTO(this RegisterDTO userdto)
        {
            return new User
            {
                FirstName = userdto.FirstName,
                LastName = userdto.LastName,
                City = userdto.City,
                Email = userdto.EmailAddress,
                UserName = userdto.UserName,
                PhoneNumber = userdto.PhoneNumber,

            };
        }
        public static UserDetailsDTO ToUserDetailsFromUser(this AppUser appUser)
        {
            return new UserDetailsDTO
            {
                Id = appUser.Id,
                UserName = appUser.UserName,
                PhoneNumber = appUser.PhoneNumber,
                City = appUser.City,
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                AccessFailedCount = appUser.AccessFailedCount,
                EmailAddress = appUser.Email,
                IsEmailConfirmed = appUser.EmailConfirmed


            };

        }
    }
}