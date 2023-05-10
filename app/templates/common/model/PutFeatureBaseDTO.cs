using System;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.Model.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.Model
<% } -%>
{
    public abstract class Put<%= featureName %>BaseDTO
    {
        public long Id { get; set; }
    }
}
