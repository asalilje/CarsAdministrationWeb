using System.Web.Mvc;
using Antlr.Runtime.Misc;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Cars.Administration.Web.Infrastructure
{
    public class ActionFilterRegistry : Registry
    {
        public ActionFilterRegistry(Func<IContainer> containerFactory)
        {
            For<IFilterProvider>()
                    .Use(new StructureMapFilterProvider(containerFactory));
        }
    }
}