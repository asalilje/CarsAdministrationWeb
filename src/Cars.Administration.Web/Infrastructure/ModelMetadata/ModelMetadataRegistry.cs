using System.Web.Mvc;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Cars.Administration.Web.Infrastructure.ModelMetadata
{
	public class ModelMetadataRegistry : Registry
	{
		public ModelMetadataRegistry()
		{
			For<ModelMetadataProvider>().Use<ExtensibleModelMetadataProvider>();
			Scan(scan =>
			{
				scan.TheCallingAssembly();
				scan.AddAllTypesOf<IModelMetadataFilter>();
			});
		}
	}
}