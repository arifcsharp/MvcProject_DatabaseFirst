using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using MVCProject_Arif.Models;
using MVCProject_Arif.ViewModels;
using AutoMapper;

namespace MVCProject_Arif
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Mapper.Initialize(config =>
            {
                config.CreateMap<EmployeeVM, Employee>();
                config.CreateMap<Employee, EmployeeVM>();
            });

        }

        

    }
}
