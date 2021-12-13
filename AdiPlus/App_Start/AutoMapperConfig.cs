using AdiPlus.ViewModels.Mappings;
using AutoMapper;

namespace MoreHealth.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappers()
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile<UserMappingProfile>();
            });

            mapperConfig.AssertConfigurationIsValid();
        }
    }
}
