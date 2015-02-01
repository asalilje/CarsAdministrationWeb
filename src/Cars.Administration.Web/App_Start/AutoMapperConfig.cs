using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;
using Cars.Administration.Web.Domain;
using Cars.Administration.Web.Infrastructure.Mapping;
using Cars.Administration.Web.Infrastructure.Tasks;
using Cars.Administration.Web.Models;
using WebGrease.Css.Extensions;

namespace Cars.Administration.Web
{
    public class AutoMapperConfig : IRunAtStartup
    {
        public void Execute()
        {
            var types = Assembly.GetExecutingAssembly().GetExportedTypes();
            LoadStandardMappings(types);
            LoadCustomMappings(types);
        }

        private void LoadCustomMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                where typeof (IHaveCustomMappings).IsAssignableFrom(t)
                      && !t.IsAbstract
                      && !t.IsInterface
                select ((IHaveCustomMappings) Activator.CreateInstance(t)));

            maps.ForEach(x => x.CreateMappings(Mapper.Configuration));
        }

        private void LoadStandardMappings(IEnumerable<Type> types)
        {
            var maps = (from t in types
                from i in t.GetInterfaces()
                where i.IsGenericType
                      && i.GetGenericTypeDefinition() == typeof (IMapFrom<>)
                      && !t.IsAbstract
                      && !t.IsInterface
                select new
                {
                    Source = i.GetGenericArguments()[0],
                    Destination = t
                });

            maps.ForEach(x => Mapper.CreateMap(x.Source, x.Destination));
            
        }
    }
}