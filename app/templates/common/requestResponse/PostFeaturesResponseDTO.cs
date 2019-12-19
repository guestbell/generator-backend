using GuestBell.Common.Base;
using System.Collections.Generic;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Common.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Post<%= featureName %>sResponseDTO : BaseResponseDTO
    {
        public List<long> Ids { get; set; }
    }
}
