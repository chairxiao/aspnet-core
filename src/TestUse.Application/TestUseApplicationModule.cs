using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using TestUse.Authorization;

namespace TestUse
{
    [DependsOn(
        typeof(TestUseCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TestUseApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TestUseAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TestUseApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
