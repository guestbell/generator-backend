using System.Collections.Generic;
using GuestBell.Common.Base;
<%if(namespaceRequestResponse) { -%>
using GuestBell.Common.<%= projectName %>.Model.<%= featureName %>;
<% } else { -%>
using GuestBell.Common.<%= projectName %>.Model;
<% } -%>

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Post<%= featureName %>sRequestDTO : BaseRequestDTO
    {
<%if(isBoundToProperty) { -%>
        public long PropertyId { get; set; }
        
<% } -%>
        public List<Post<%= featureName %>DTO> <%= featureName %>s { get; set; }
    }
}
