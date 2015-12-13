using CERental.Core.Domain;
using CERental.Core.Dto;

namespace CERental.ApplicationServices.Mappers
{
    public static class ApplicationUserMapper
    {
        public static ApplicationUserDto MapToDto(this ApplicationUser user)
        {
            return new ApplicationUserDto()
            {
                Id = user.Id,
                Email = user.Email
            };
        }
    }
}