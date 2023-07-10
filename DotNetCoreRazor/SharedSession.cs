using Microsoft.AspNetCore.SystemWebAdapters;
using System.Text;
using System.Web.SessionState;

namespace DotNetCoreRazor;
public static class SharedSession
{  
    [Session]
    public static Dictionary<string, object?> GetSharedSessionObject(HttpContext context)
    {
        var sharedSessionVariables = new Dictionary<string, object?>();
        var adapter = (System.Web.HttpContext)context;
        sharedSessionVariables.Add("SessionID", adapter.Session!.SessionID);
        sharedSessionVariables.Add("UserName",adapter.Session!["UserName"]);
        sharedSessionVariables.Add("CurrentTime",adapter.Session!["CurrentTime"]);
        return sharedSessionVariables;

    }
}