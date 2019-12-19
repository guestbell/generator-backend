using GuestBell.Common.Dal.Base;
using System.Collections.Generic;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Put<%= featureName %>sSqlResponseDTO : BaseSqlResponseDTO
    {
    }
}
