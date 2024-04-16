using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace BulkyWeb.Filters
{
    public class AjaxOnlyAttribute : ActionMethodSelectorAttribute
    {
        // Is this request come from ajax? (In request Header "XMLHttpRequest")
        public override bool IsValidForRequest(RouteContext routeContext, ActionDescriptor action)
        {
            var request = routeContext.HttpContext.Request;
            var isAjax = request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return isAjax;
        }
    }
}
