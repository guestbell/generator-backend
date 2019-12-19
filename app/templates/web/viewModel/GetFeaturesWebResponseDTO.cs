using GuestBell.Common.Web.Base;
using System.Collections.Generic;
using GuestBell.Common.Web.Model.<%= featureName %>;

namespace GuestBell.Common.Web.ViewModel.<%= featureName %>
{
    public class Get<%= featureName %>sWebResponseDTO : BaseWebResponseDTO
    {
        <%if(!isPaginated) {
        %>public List<<%= featureName %>WebDTO> <%= featureName %>s { get; set; }<%
        } else {
        %>public PaginatedDataWebDTO<<%= featureName %>WebDTO> <%= featureName %>s { get; set; }<%
        } %>
    }
}
