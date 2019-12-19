using System.Collections.Generic;
using GuestBell.Common.Web.Base;
<%if(isPaginated) { %>using GuestBell.Common.Web.Model.<%= featureName %>.Enum;<%} %>

namespace GuestBell.Common.Web.ViewModel.<%= featureName %>
{
    public class Get<%= featureName %>sWebRequestDTO : <% if(!isPaginated) { %>BaseWebRequestDTO<% } else {%>PaginatedWebRequestDTO<<%= featureName %>ColumnNameWebEnum><% }%>
    {
    }
}
