using System.Collections.Generic;
using GuestBell.Common.Dal.Base;

<%if(namespaceRequestResponse) { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>
<% } else { -%>
namespace GuestBell.Dal.<%= projectName %>.RequestResponse
<% } -%>
{
    public class Delete<%= featureName %>sSqlRequestDTO : BaseSqlRequestDTO
    {
        <%if(isBoundToProperty) { -%>
        public long PropertyId { get; set; }

        <% } -%>
        public List<long> Ids { get; set; }

public bool Revert { get; set; } = false;
    }
}
