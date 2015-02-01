using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Cars.Administration.Web.Infrastructure
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
         
    }
}