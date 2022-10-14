using System;
<%if(namespaceRequestResponse) { -%>
using GuestBell.Common.<%= projectName %>.Model.<%= featureName %>
<% } else { -%>
using GuestBell.Common.<%= projectName %>.Model
<% } -%>

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class <%= featureName %>SqlDTO : <%= featureName %>BaseDTO
    {
    }
}
