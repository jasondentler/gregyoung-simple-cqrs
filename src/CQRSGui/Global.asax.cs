using System;
using System.Configuration;
using GuyWire;

namespace CQRSGui
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
        	var startupTypeString = ConfigurationManager.AppSettings["GuyWire"];
        	var startupType = Type.GetType(startupTypeString);
        	var startup = (IGuyWire) Activator.CreateInstance(startupType);
			startup.Wire();
        }

    }
}