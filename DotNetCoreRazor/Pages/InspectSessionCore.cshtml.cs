using DotNetCoreRazor.Extensions;
using DotNetCoreRazor.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace DotNetCoreRazor.Pages
{
    public class InspectSessionCoreModel : PageModel
    {
        public _SessionExplorerModel SharedSessionExplorerModel;
        public _SessionExplorerModel DifferentSessionExplorerModel;
        public _SessionExplorerModel ExistingSessionExplorerModel;

        public async Task OnGet()
        {
            await SetDifferentSessionAsync();
            SetNetCoreSession();
            GetSharedSession();
        }

        private async Task SetDifferentSessionAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value);
            DifferentSessionExplorerModel = new();
            DifferentSessionExplorerModel.Collection = JsonSerializer.Deserialize<System.Collections.IDictionary?>(await client.GetStringAsync("/session"));
            DifferentSessionExplorerModel.Heading = "Calling /session with HttpClient";
        }

        private void GetSharedSession()
        {
            SharedSessionExplorerModel = new _SessionExplorerModel();
            SharedSessionExplorerModel.Collection = SharedSession.GetSharedSessionObject(HttpContext);
            SharedSessionExplorerModel.Heading = "Shared Session via System.Web Adapters";
        }

        private void SetNetCoreSession()
        {
            HttpContext.Session.SetString("UserName", ("testUser" + DateTime.Now.Second.ToString()));
            ExistingSessionExplorerModel = new _SessionExplorerModel();
            ExistingSessionExplorerModel.SessionID = HttpContext.Session.Id;
            ExistingSessionExplorerModel.Collection = HttpContext.Session.ToDictionary();
            ExistingSessionExplorerModel.Heading = ".NET Core Session";
        }
    }
}
