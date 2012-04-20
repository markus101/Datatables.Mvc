using DataTables.Mvc.Core.Helpers;
using DataTables.Mvc.Core.Models﻿;
using System;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Microsoft.Web.Infrastructure;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.DataTablesModelBinderActivator), "Start")]

namespace $rootnamespace$.App_Start
{
    public static class DataTablesModelBinderActivator
    {
        public static void Start()
        {
            if (!ModelBinders.Binders.ContainsKey(typeof(DataTablesParams)))
                ModelBinders.Binders.Add(typeof(DataTablesParams), new DataTablesModelBinder());
        }
    }
}