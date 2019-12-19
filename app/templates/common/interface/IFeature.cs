<%if(namespaceRequestResponse) { -%>
using GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>;
<% } else { -%>
using GuestBell.Common.<%= projectName %>.RequestResponse;
<% } -%>
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestBell.Common.<%= projectName %>.Interface
{
    public interface I<%= featureName %>
    {
<% if(includePost) { -%>
        Task<Post<%= featureName %>sResponseDTO> Post(Post<%= featureName %>sRequestDTO request);
<% } -%>
<% if(includeGet) { %>
        Task<Get<%= featureName %>sResponseDTO> Get(Get<%= featureName %>sRequestDTO request);
<% } -%>
<% if(includeDelete) { -%>
        Task<Delete<%= featureName %>sResponseDTO> Delete(Delete<%= featureName %>sRequestDTO request);
<% } -%>
<% if(includePut) { -%>
        Task<Put<%= featureName %>sResponseDTO> Put(Put<%= featureName %>sRequestDTO request);
<% } -%>
    }
}
