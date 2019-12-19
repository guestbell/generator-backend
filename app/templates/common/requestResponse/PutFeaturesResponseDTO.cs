using GuestBell.Common.Base;
using System.Collections.Generic;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Put<%= featureName %>sResponseDTO : BaseResponseDTO
    {
    }
}
