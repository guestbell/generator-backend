<%if(namespaceRequestResponse) { -%>
using GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>;
<% } else { -%>
using GuestBell.Dal.<%= projectName %>.RequestResponse;
<% } -%>
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuestBell.Dal.<%= projectName %>.Interface
{
    public interface I<%= featureName %>Dal
    {
<% if(includePost) { -%>
        Task<Post<%= featureName %>sSqlResponseDTO> Post(Post<%= featureName %>sSqlRequestDTO request);
<% } -%>
<% if(includePost && (includeGet || includeDelete || includePut)) { -%>

<% } -%>
<% if(includeGet) { -%>
        Task<Get<%= featureName %>sSqlResponseDTO> Get(Get<%= featureName %>sSqlRequestDTO request);
<% } -%>
<% if(includeGet && (includeDelete || includePut)) { -%>

<% } -%>
<% if(includeDelete) { -%>
        Task<Delete<%= featureName %>sSqlResponseDTO> Delete(Delete<%= featureName %>sSqlRequestDTO request);
<% } -%>
<% if(includeGet && includePut) { -%>

<% } -%>
<% if(includePut) { -%>
        Task<Put<%= featureName %>sSqlResponseDTO> Put(Put<%= featureName %>sSqlRequestDTO request);
<% } -%>
    }
}
