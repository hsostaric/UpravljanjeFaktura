using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using ZadatakFaktureMVC5.Repositories;

namespace ZadatakFaktureMVC5
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // container.RegisterType<IUserRepository, UserRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}