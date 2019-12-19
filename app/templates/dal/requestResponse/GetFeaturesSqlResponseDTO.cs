using GuestBell.Common.Dal.Base;
using System.Collections.Generic;
using GuestBell.Dal.<%= projectName %>.Model;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Get<%= featureName %>sSqlResponseDTO : BaseSqlResponseDTO
    {
        <%if(!isPaginated) {
        %>public List<<%= featureName %>DTO> <%= featureName %>s { get; set; }<%
        } else {
        %>public PaginatedDataSqlDTO<<%= featureName %>SqlDTO> <%= featureName %>s { get; set; }<%
        } %>
    }
}
