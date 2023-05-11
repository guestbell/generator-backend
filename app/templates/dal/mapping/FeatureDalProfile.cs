using AutoMapper;
using GuestBell.Common.Model.Common;
using GuestBell.Common.Model.Common.Enum;
using GuestBell.Common.<%= projectName %>.Model;
<%if(namespaceRequestResponse) { -%>
using GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>;
<% } else { -%>
using GuestBell.Common.<%= projectName %>.RequestResponse;<%
} -%>
<%if(namespaceRequestResponse) { -%>
using GuestBell.Common.<%= projectName %>.Model.<%= featureName %>;
<% } else { -%>
using GuestBell.Common.<%= projectName %>.Model;
<% } -%>
<%if(namespaceRequestResponse) { -%>
using GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>;
<% } else { -%>
using GuestBell.Dal.<%= projectName %>.RequestResponse;
<% } -%>
<%if(namespaceRequestResponse) { -%>
using GuestBell.Dal.<%= projectName %>.Model.<%= featureName %>;
<% } else { -%>
using GuestBell.Dal.<%= projectName %>.Model;
<% } -%>

namespace GuestBell.Dal.<%= projectName %>.Mapping
{
    public class <%= featureName %>DalProfile : Profile
    {
        public <%= featureName %>DalProfile()
        {
<% if(includeGet) { -%>
            CreateMap<<%= featureName %>SqlDTO, <%= featureName %>DTO>();
<% } -%>
<% if(includePut) { -%>
            CreateMap<Put<%= featureName %>DTO, Put<%= featureName %>SqlDTO>();
<% } -%>
<% if(includePost) { -%>
            CreateMap<Post<%= featureName %>DTO, Post<%= featureName %>SqlDTO>();
<% } -%>
<% if(includeGet || includePut || includePost) { -%>

<% } -%>
<% if(includeDelete) { -%>
            CreateMap<Delete<%= featureName %>sRequestDTO, Delete<%= featureName %>sSqlRequestDTO>();
            CreateMap<Delete<%= featureName %>sSqlResponseDTO, Delete<%= featureName %>sResponseDTO>();

<% } -%>
<% if(includeGet) { -%>
            CreateMap<Get<%= featureName %>sRequestDTO, Get<%= featureName %>sSqlRequestDTO>();
            CreateMap<Get<%= featureName %>sSqlResponseDTO, Get<%= featureName %>sResponseDTO>();
            
<% } -%>
<% if(includePost) { -%>
            CreateMap<Post<%= featureName %>sRequestDTO, Post<%= featureName %>sSqlRequestDTO>();
            CreateMap<Post<%= featureName %>sSqlResponseDTO, Post<%= featureName %>sResponseDTO>();

<% } -%>
<% if(includePut) { -%>
            CreateMap<Put<%= featureName %>sSqlResponseDTO, Put<%= featureName %>sResponseDTO>();
            CreateMap<Put<%= featureName %>sRequestDTO, Put<%= featureName %>sSqlRequestDTO>();
<% } -%>
        }
    }
}
