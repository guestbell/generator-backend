using System.Collections.Generic;
using GuestBell.Common.Base;
<%if(isPaginated) { %>using GuestBell.Common.<%= projectName %>.Model.Enum;<%} -%>

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Get<%= featureName %>sRequestDTO : <% if(!isPaginated) { %>BaseRequestDTO<% } else {%>PaginatedRequestDTO<<%= featureName %>ColumnNameEnum><% }%>
    {
        <%if(isBoundToProperty) { -%>
        public long PropertyId { get; set; }
        
        <% } -%>
        public List<long> Ids { get; set; }
    }
}
