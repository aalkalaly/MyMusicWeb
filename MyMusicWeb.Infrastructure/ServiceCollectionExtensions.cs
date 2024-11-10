using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicWeb.Infrastructure
{
    using System.Reflection;
    using MyMusicWebDataModels;
    using Microsoft.Extensions.DependencyInjection;
    using MyMusicWebData.Repository.Interfaces;
    using MyMusicWebData.Repository;

    public static class ServiceCollectionExtensions
    {
        public static void RegisterRepostitories(this IServiceCollection services, Assembly modelsAssembly)
        {
            Type[] typesToExclude = new Type[] { typeof(ApplicationUser) };
            Type[] modelTypes = modelsAssembly
                .GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface &&
                            !t.Name.ToLower().EndsWith("attribute"))
                .ToArray();

            foreach (Type type in modelTypes)
            {
                if (!typesToExclude.Contains(type))
                {
                    Type repositoryInterface = typeof(IRepository<,>);
                    Type repositoryInstanceType = typeof(BaseRepository<,>);
                    PropertyInfo? idPropInfo = type
                        .GetProperties()
                        .Where(p => p.Name.ToLower() == "id")
                        .SingleOrDefault();

                    Type[] constructArgs = new Type[2];
                    constructArgs[0] = type;

                    if (idPropInfo == null)
                    {
                        constructArgs[1] = typeof(object);
                    }
                    else
                    {
                        constructArgs[1] = idPropInfo.PropertyType;
                    }

                    repositoryInterface = repositoryInterface.MakeGenericType(constructArgs);
                    repositoryInstanceType = repositoryInstanceType.MakeGenericType(constructArgs);

                    services.AddScoped(repositoryInterface, repositoryInstanceType);
                }
            }
        }
    }
}
