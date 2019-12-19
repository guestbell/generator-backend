using GuestBell.Common.Base;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Delete<%= featureName %>sResponseDTO : BaseResponseDTO
    {
    }
}
