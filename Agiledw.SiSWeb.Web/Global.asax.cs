using Agiledw.SiSWeb.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Agiledw.SiSWeb.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //throw new Exception(ConfigurationManager.ConnectionStrings["EfDbContext"].ConnectionString);
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfDbContext, Configuration());

        }
    }
}
