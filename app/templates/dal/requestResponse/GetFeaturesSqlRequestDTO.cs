using System.Collections.Generic;
using GuestBell.Common.Dal.Base;
<%if(isPaginated) { %>using GuestBell.Dal.<%= projectName %>.Model.Enum;<% } -%>

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Get<%= featureName %>sSqlRequestDTO : <% if(!isPaginated) { %>BaseSqlRequestDTO<% } else {%>PaginatedSqlRequestDTO<<%= featureName %>ColumnNameSqlEnum><% }%>
    {
        <%if(isBoundToProperty) { -%>
        public long PropertyId { get; set; }
        
        <% } -%>
        public List<long> Ids { get; set; }
    }
}
