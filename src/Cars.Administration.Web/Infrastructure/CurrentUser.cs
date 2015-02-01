using System.Net;
using System.Security.Principal;
using Cars.Administration.Web.Domain;

namespace Cars.Administration.Web.Infrastructure
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IIdentity _identity;
        private ApplicationUser _user;

        public CurrentUser(IIdentity identity)
        {
            _identity = identity;
        }

        public ApplicationUser User
        {
            get { return _user ?? (_user = new ApplicationUser {UserId = _identity.Name}); }
        }
    }
}