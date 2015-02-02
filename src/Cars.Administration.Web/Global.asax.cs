using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Cars.Administration.Web.Infrastructure;
using Cars.Administration.Web.Infrastructure.ModelMetadata;
using Cars.Administration.Web.Infrastructure.Tasks;
using Cars.Administration.Web.Repository;
using StructureMap;
using StructureMap.Graph;

namespace Cars.Administration.Web
{
		public class MvcApplication : HttpApplication
		{

				public IContainer Container
				{
						get { return (IContainer)HttpContext.Current.Items["Container"]; }
						set { HttpContext.Current.Items["Container"] = value; }
				}
				
				protected void Application_Start()
				{
						AreaRegistration.RegisterAllAreas();
						FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
						RouteConfig.RegisterRoutes(RouteTable.Routes);
						BundleConfig.RegisterBundles(BundleTable.Bundles);

						DependencyResolver.SetResolver(new StructureMapDependencyResolver(
								() => Container ?? ObjectFactory.Container));

						
						ObjectFactory.Configure(cfg =>
						{
								cfg.AddRegistry<StandardRegistry>();
								cfg.AddRegistry<ControllerRegistry>();
								cfg.AddRegistry<RepositoryRegistry>();
								cfg.AddRegistry(new ActionFilterRegistry(() => Container ?? ObjectFactory.Container));
								cfg.AddRegistry<MvcRegistry>();
								cfg.AddRegistry<TaskRegistry>();
								cfg.AddRegistry<ModelMetadataRegistry>();
						});

						using (var container = ObjectFactory.Container.GetNestedContainer())
						{
								foreach (var task in container.GetAllInstances<IRunAtStartup>())
								{
										task.Execute();
								}
						}
				}

				protected void Application_BeginRequest()
				{
						Container = ObjectFactory.Container.GetNestedContainer();
						foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
						{
								task.Execute();
						}
				}

				protected void Application_Error()
				{
						foreach (var task in Container.GetAllInstances<IRunOnError>())
						{
								task.Execute();
						}
				}

				protected void Application_EndRequest()
				{
						try
						{
								foreach (var task in Container.GetAllInstances<IRunAfterEachRequest>())
								{
										task.Execute();
								}
						}
						finally
						{
								Container.Dispose();
								Container = null;    
						}
						
				}
		}
}