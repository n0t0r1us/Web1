﻿using System.Web;
using System.Web.Mvc;

namespace KT0720Thanh_61654321
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
