using CodingTest.Common.MEF;
using StructureMap;

namespace CodingTest.WebApi2
{
    public static class StructureMapConfig
    {
        public static IContainer RegisterComponents()
        {
            var container = BuildContainer();

            // DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IContainer BuildContainer()
        {
            var container = new Container();

            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IContainer container)
        {
            //container.RegisterType<IUser, User>();

            //Module initialization thru MEF
            StructureMapModuleLoader.LoadContainer(container, ".\\bin", "CodingTest.*.dll");
        }

        public static IContainer RegisterComponents(IContainer container)
        {
            RegisterTypes(container);

            return container;
        }

    }
}