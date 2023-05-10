using System.Collections.Generic;
using GuestBell.Common.Dal.Base;
<%if(isPaginated) { %>using GuestBell.Common.<%= projectName %>.Model.Enum;<% } -%>

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Get<%= featureName %>sSqlRequestDTO : <% if(!isPaginated) { %>BaseSqlRequestDTO<% } else {%>PaginatedSqlRequestDTO<<%= featureName %>ColumnNameEnum><% }%>
    {
<%if(isBoundToProperty) { -%>
        public long PropertyId { get; set; }
        
<% } -%>
<%if(ignorePropertyId) { -%>
        public bool IgnorePropertyId { get; set; }
        
<% } -%>
<%if(exceptIds) { -%>
        public List<long> ExceptIds { get; set; }
        
<% } -%>
        public List<long> Ids { get; set; }
    }
}
