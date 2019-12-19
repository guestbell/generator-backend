using System.Collections.Generic;
using GuestBell.Common.Dal.Base;
using GuestBell.Dal.<%= projectName %>.Model;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Put<%= featureName %>sSqlRequestDTO : BaseSqlRequestDTO
    {
        <%if(isBoundToProperty) { -%>
        public long PropertyId { get; set; }
        
        <% } -%>
        public List<Put<%= featureName %>SqlDTO> <%= featureName %>s { get; set; }
    }
}
