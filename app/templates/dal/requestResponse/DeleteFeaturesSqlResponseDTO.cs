using GuestBell.Common.Dal.Base;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Delete<%= featureName %>sSqlResponseDTO : BaseSqlResponseDTO
    {
    }
}
