using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace Cars.Administration.Web.Infrastructure.ModelMetadata
{
	public class ExtensibleModelMetadataProvider : DataAnnotationsModelMetadataProvider
	{
		private readonly IModelMetadataFilter[] _metadataFilters;

		public ExtensibleModelMetadataProvider(IModelMetadataFilter[] metadataFilters)
		{
			_metadataFilters = metadataFilters;
		}

		protected override System.Web.Mvc.ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes,
			Type containerType, Func<object> modelAccessor, Type modelType,
			string propertyName)
		{
			var metadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
			_metadataFilters.ForEach(x => x.TransformMetadata(metadata, attributes));
			return metadata;
		}
	}
}