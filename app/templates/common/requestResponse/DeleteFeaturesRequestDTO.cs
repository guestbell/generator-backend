using System.Collections.Generic;
using GuestBell.Common.Base;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Delete<%= featureName %>sRequestDTO : BaseRequestDTO
    {
<%if(isBoundToProperty) { -%>
        public long PropertyId { get; set; }

<% } -%>
        public List<long> Ids { get; set; }

        public bool Revert { get; set; } = false;
    }
}
