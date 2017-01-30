namespace CrossOver.Tests.Common
{
    public static class TestBootstrapper
    {
        public static void TestRepositoryStructureMap()
        {
            ObjectFactory.Container.Dispose();
            ObjectFactory.Container.Configure(o => o.AddRegistry(new StructureMapRepositoryTestRegistry()));
            ObjectFactory.Container.AssertConfigurationIsValid();
        }
    }
}
