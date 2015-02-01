using Cars.Administration.Web.Domain;

namespace Cars.Administration.Web.Infrastructure
{
    public interface ICurrentUser
    {
        ApplicationUser User { get; } 
    }
}