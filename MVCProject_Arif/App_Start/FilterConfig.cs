﻿using System.Web;
using System.Web.Mvc;

namespace MVCProject_Arif
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}