using GuestBell.Common.Dal.Base;
using System.Collections.Generic;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Post<%= featureName %>sSqlResponseDTO : BaseSqlResponseDTO
    {
        public List<long> Ids { get; set; }
    }
}
