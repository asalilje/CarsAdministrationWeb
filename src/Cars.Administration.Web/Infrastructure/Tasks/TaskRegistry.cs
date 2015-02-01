using System;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Cars.Administration.Web.Infrastructure.Tasks
{
    public class TaskRegistry : Registry
    {
        public TaskRegistry()
        {
            Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory(a => a.FullName.StartsWith("Cars"));
                scan.AddAllTypesOf<IRunAfterEachRequest>();
                scan.AddAllTypesOf(typeof(IRunAtStartup));
                scan.AddAllTypesOf<IRunOnEachRequest>();
                scan.AddAllTypesOf<IRunOnError>();
            });
        }
    }
}