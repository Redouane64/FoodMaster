using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Domain;
using FoodMaster.WebSite.Events;

using MediatR;

namespace FoodMaster.WebSite.Subscribers
{
    public class SignOutNotificationHandler : NotificationHandler<SignOutNotification>
    {
        private readonly IUsersService usersService;

        public SignOutNotificationHandler(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        protected override void Handle(SignOutNotification notification)
        {
            var user = usersService.Get(u => u.Id == notification.UserId);

            if(user.Role == Roles.Guest.ToString())
            {
                usersService.Delete(user);
            }
        }
    }
}
