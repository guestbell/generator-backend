using System;
<%if(namespaceRequestResponse) { -%>
using GuestBell.Common.<%= projectName %>.Model.<%= featureName %>;
<% } else { -%>
using GuestBell.Common.<%= projectName %>.Model;
<% } -%>

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.Model.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.Model
<% } -%>
{
    public class Put<%= featureName %>SqlDTO : Put<%= featureName %>BaseDTO 
    {
    }
}
