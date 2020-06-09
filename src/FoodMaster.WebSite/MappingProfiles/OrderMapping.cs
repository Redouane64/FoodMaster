using System.Linq;
using System.Security.Claims;
using AutoMapper;

using FoodMaster.WebSite.Abstraction.Services;
using FoodMaster.WebSite.Queries.Common;
using Microsoft.AspNetCore.Http;

namespace FoodMaster.WebSite.MappingProfiles
{
    public class OrderMapping : Profile
    {
        public OrderMapping()
        {
            CreateMap<Domain.Order, Order>()
                .ForMember(dest => dest.Client, options => options.MapFrom<ClientFullNameValueResolver, string>(s => s.UserId));
        }

        private class ClientFullNameValueResolver : IMemberValueResolver<Domain.Order, Order, string, string>
        {
            private readonly IUsersService usersService;

            public ClientFullNameValueResolver(IUsersService usersService)
            {
                this.usersService = usersService;
            }

            public string Resolve(Domain.Order source, Order destination, string sourceMember, string destMember, ResolutionContext context)
            {
                return usersService.GetById(source.UserId).FullName;
            }
        }
    }
}
