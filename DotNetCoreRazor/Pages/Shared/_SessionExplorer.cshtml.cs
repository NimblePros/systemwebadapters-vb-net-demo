using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;

namespace DotNetCoreRazor.Pages.Shared
{
    public class _SessionExplorerModel : PageModel
    {
        public string SessionID { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public IDictionary? Collection { get; set; }
        public string Heading { get; set; } = string.Empty;
    }
}
