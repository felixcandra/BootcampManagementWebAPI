using BusinessLogic.Service;
using BusinessLogic.Service.Master;
using Common.Interface;
using Common.Interface.Master;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace BootcampManagementWebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            //this is service area
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IRegencyService, RegencyService>();
            container.RegisterType<IReligionService, ReligionService>();
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<IVillageService, VillageService>();
            container.RegisterType<IUniversityService, UniversityService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<IHistoryEducationService, HistoryEducationService>();
            container.RegisterType<IDailyScoreService, DailyScoreService>();
            container.RegisterType<IWeeklyScoreService, WeeklyScoreService>();

            //this is repository area
            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<IRegencyRepository, RegencyRepository>();
            container.RegisterType<IReligionRepository, ReligionRepository>();
            container.RegisterType<IDistrictRepository, DistrictRepository>();
            container.RegisterType<IVillageRepository, VillageRepository>();
            container.RegisterType<IUniversityRepository, UniversityRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IHistoryEducationRepository, HistoryEducationRepository>();
            container.RegisterType<IDailyScoreRepository, DailyScoreRepository>();
            container.RegisterType<IWeeklyScoreRepository, WeeklyScoreRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}