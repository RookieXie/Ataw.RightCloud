using System.Web.Mvc;
//using System.Web.Optimization;
//using System.Web.Optimization.React;


namespace Ataw.RightCloud.Web
{
    public class RightCloudAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "RightCloud";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
             "RightCloud_Default_home",
             "ts/html/x", // URL with parameters
              new { controller = "Auth", action = "Home"},
             new[] { "Ataw.RightCloud.Web" });


            //context.MapRoute(
            //"RightCloud_Default_home",
            //"ts/html/x1", // URL with parameters
            // new { controller = "Auth", action = "Front" },
            //new[] { "Ataw.RightCloud.Web" });

            context.MapRoute(
            "RightCloud_Default_home_x1",
            "ts/html/x1", // URL with parameters
             new { controller = "Auth", action = "Front" },
            new[] { "Ataw.RightCloud.Web" });



            //context.MapRoute(
            //"RightCloud_Default_homet",
            //"ts/html/t", // URL with parameters
            // new { controller = "Auth", action = "React" },
            //new[] { "Ataw.RightCloud.Web" });


            context.MapRoute(
              "RightCloud_Default_login",
              "RightCloud/{controller}/{action}/{id}", // URL with parameters
               new { controller = "Auth", action = "Index", id = UrlParameter.Optional },
              new[] { "Ataw.RightCloud.Web" });

            context.MapRoute(
               "RightCloud_default",
               "RightCloud/{controller}/{action}/{id}",
               new { controller = "UI", action = "Home", id = UrlParameter.Optional },
                 new[] { "Ataw.RightCloud.Web", "Ataw.RightCloud.Web.Controllers" }

           );
          bundle();
        }

           

         private void bundle()
         {
            
         }
        
        
        }
    }
