﻿using System.Web;
using System.Web.Mvc;

namespace THIDinhVu_61131562
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
