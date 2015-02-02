using System;
using System.Collections.Generic;
using Cars.Administration.Web.Helpers;

namespace Cars.Administration.Web.Infrastructure.ModelMetadata.Filters
{
	public class LabelConventionFilter: IModelMetadataFilter
	{
		public void TransformMetadata(System.Web.Mvc.ModelMetadata metadata, IEnumerable<Attribute> attributes)
		{
			if (!string.IsNullOrEmpty(metadata.PropertyName) && string.IsNullOrEmpty(metadata.DisplayName))
			{
				metadata.DisplayName = metadata.PropertyName.ToStringWithSpaces();
			}
		}
	}
}