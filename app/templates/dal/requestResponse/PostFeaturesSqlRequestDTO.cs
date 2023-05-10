using System.Collections.Generic;
using GuestBell.Common.Dal.Base;
<%if(namespaceRequestResponse) { -%>
using GuestBell.Dal.<%= projectName %>.Model.<%= featureName %>;
<% } else { -%>
using GuestBell.Dal.<%= projectName %>.Model;
<% } -%>

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Post<%= featureName %>sSqlRequestDTO : BaseSqlRequestDTO
    {
<%if(isBoundToProperty) { -%>
        public long PropertyId { get; set; }
        
<% } -%>
        public List<Post<%= featureName %>SqlDTO> <%= featureName %>s { get; set; }
    }
}
