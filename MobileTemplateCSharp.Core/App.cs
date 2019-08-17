using System;
using System.Linq;
using System.Reflection;

using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

using MobileTemplateCSharp.Core.Database.Implementations;
using MobileTemplateCSharp.Core.Database.Interfaces;
using MobileTemplateCSharp.Core.Models.Database;
using MobileTemplateCSharp.Core.Rest.Interfaces;
//using MobileTemplateCSharp.Core.Rest.TestImplementation;

namespace MobileTemplateCSharp.Core {
    /// <summary>
    /// Class for creating application and initializing services, including database and rest clients.
    /// </summary>
    public class App : MvxApplication {
        public App() {
        }

        public override void Initialize() {

            //services
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Rest
            CreatableTypes()
                .EndingWith("Client")
                .DoesNotInherit(typeof(IRepositoryDBClient<>))
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Database
            Mvx.IoCProvider.RegisterType<IConnectionDBClient, ConnectionDBClient>();
            foreach (Type type in Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
                .Where(myType => myType.IsClass && myType.IsSubclassOf(typeof(BaseEntity)))
            ) {
                Mvx.IoCProvider.RegisterType(
                    typeof(IRepositoryDBClient<>).MakeGenericType(type),
                    typeof(RepositoryDBClient<>).MakeGenericType(type)
                );
            }

            // register the appstart object
            RegisterCustomAppStart<AppStart>();
        }
    }
}
