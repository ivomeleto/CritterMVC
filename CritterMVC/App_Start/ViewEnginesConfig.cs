using System.Web.Mvc;

namespace CritterMVC.App_Start
{
    public static class ViewEnginesConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
            ViewEngines.Engines.Clear(); // the goal is to remove the webforms view engine and improve performance(hopefuly)
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}