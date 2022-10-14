using System;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.Model.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.Model
<% } -%>
{
    public class Put<%= featureName %>DTO : Put<%= featureName %>BaseDTO
    {
    }
}
