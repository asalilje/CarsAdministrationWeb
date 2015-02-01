using Cars.Administration.Web.Repository;
using StructureMap.Configuration.DSL;

namespace Cars.Administration.Web.Infrastructure
{
    public class RepositoryRegistry : Registry
    {
        public RepositoryRegistry()
        {
            ForSingletonOf<ICarRepository>().Use<CarRepository>();
            ForSingletonOf<ILog>().Use<Log>();
        }
    }
}