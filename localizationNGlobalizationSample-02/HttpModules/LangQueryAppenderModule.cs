using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace localizationNGlobalizationSample_02.HttpModules
{
    public class LangQueryAppenderModule : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += (new EventHandler(this.Application_BeginRequest));
        }




        private readonly IList<string> _supportedLocales;
        private readonly IList<string> _controllersNamesList;

        public LangQueryAppenderModule()
        {
            // Get list of supported locales 
            _supportedLocales = Utils.LocalizationHelper.GetSupportedLocales();

            // Get controllers list of current project by reflection
            var asmPath = HttpContext.Current.Server.MapPath("~/bin/RoutedLocalizationExample.dll");
            Assembly asm = Assembly.LoadFile(asmPath);

            var controllerTypes = asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type));
            _controllersNamesList = new List<string>();

            foreach (var controllerType in controllerTypes)
            {
                var fullName = controllerType.Name;

                // We need only name part of Controller class that is used in route
                _controllersNamesList.Add(fullName.Substring(0, fullName.Length - "Controller".Length));
            }
        }

        private void Application_BeginRequest(Object source, EventArgs e)
        {
            try
            {
                HttpApplication app = (HttpApplication)source;
                HttpContext ctx = app.Context;

                // We will redirect to url with defined locale only in case for HTTP GET verb
                // cause we assume that all requests with other verbs will be called from site directly
                // where all the urls created with URLHelper, so it complies with routing rules and will contain "lang" parameter
                if (string.Equals(ctx.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase))
                {
                    var localisedUri = Utils.LocalizationHelper.GetLocalisedUrl(ctx.Request.Url, _controllersNamesList, ctx.Request.UserLanguages);
                    if (!string.IsNullOrEmpty(localisedUri))
                        // Perform redirect action to changed url if it exists
                        ctx.Response.Redirect(localisedUri);
                }
            }
            catch (Exception)
            {
                // Some logging logic could be here
            }
        }
    }
}