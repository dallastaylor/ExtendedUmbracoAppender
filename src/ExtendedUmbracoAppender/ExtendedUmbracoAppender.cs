using System.Web;
using log4net.Core;

namespace ExtendedUmbracoAppender
{
    public class ExtendedUmbracoAppender : Umbraco.Core.Logging.AsynchronousRollingFileAppender
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            var host = "-";

            // check for handler to prevent exception when there is no request. See http://stackoverflow.com/a/22858555/97970
            if (HttpContext.Current != null && HttpContext.Current.Handler != null)
            {
                host = HttpContext.Current.Request.Url.Host;
            }

            if (loggingEvent.Properties != null) loggingEvent.Properties["host"] = host;

            base.Append(loggingEvent);
        }
    }
}