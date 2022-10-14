using System;
<%if(namespaceRequestResponse) { -%>
using GuestBell.Common.<%= projectName %>.Model.<%= featureName %>
<% } else { -%>
using GuestBell.Common.<%= projectName %>.Model
<% } -%>

namespace GuestBell.Common.Web.Model.<%= featureName %>
{
    public class Put<%= featureName %>WebDTO : Put<%= featureName %>BaseDTO
    {
    }
}
