using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace FoodMaster.WebSite.Events
{
    public class SignOutNotification : INotification
    {
        public string UserId { get; }

        public SignOutNotification(string userId)
        {
            UserId = userId;
        }
    }
}
