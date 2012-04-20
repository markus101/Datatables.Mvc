﻿using DataTables.Mvc.Core.Models﻿
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Microsoft.Web.Infrastructure;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivator.PreApplicationStartMethod(
typeof($rootnamespace$.App_Start.DataTablesModelBinder), "PreStart")]

namespace $rootnamespace$.App_Start
{
    public static class DataTablesModelBinder
    {
        public static void PreStart()
        {
            if (!ModelBinders.Binders.ContainsKey(typeof(DataTablesParams)))
                ModelBinders.Binders.Add(typeof(DataTablesParams), new DataTablesModelBinder());
        }
    }
}