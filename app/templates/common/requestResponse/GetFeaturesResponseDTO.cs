using GuestBell.Common.Base;
using System.Collections.Generic;
using GuestBell.Common.<%= projectName %>.Model;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Get<%= featureName %>sResponseDTO : BaseResponseDTO
    {
        <%if(!isPaginated) {
        %>public List<<%= featureName %>DTO> <%= featureName %>s { get; set; }<%
        } else {
        %>public PaginatedDataDTO<<%= featureName %>DTO> <%= featureName %>s { get; set; }<%
        } %>
    }
}
