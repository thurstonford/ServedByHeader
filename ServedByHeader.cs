using System;
using System.Web;

namespace COGWare
{
    class ServedByHeader : IHttpModule
    {
        public static readonly string _servedBy = Environment.GetEnvironmentVariable("NodeName", EnvironmentVariableTarget.Machine) ?? String.Empty;

        public void Dispose() {
            
        }

        public void Init(HttpApplication context) {
            // Register the Post Request event handler - we add the custom HTTP header after the request has been handled
            context.PostRequestHandlerExecute += new EventHandler(Context_PostRequestHandlerExecute);
        }

        private void Context_PostRequestHandlerExecute(object sender, EventArgs e) {
            try {
                // Get the node name from the server environment variables and 
                // add a custom header to the response with this value
                ((HttpApplication)sender).Context.Response.Headers.Add("ServedBy", _servedBy);
            } catch (Exception ex) {
                // Write the error to the system logs
                System.Diagnostics.EventLog.WriteEntry(
                    "Application", 
                    $"Error adding ServedBy header to response: {ex.GetBaseException()}", 
                    System.Diagnostics.EventLogEntryType.Error);
            }
        }
    }
}
