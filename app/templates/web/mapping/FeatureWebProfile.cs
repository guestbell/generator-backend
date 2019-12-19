using AutoMapper;
<%if(namespaceRequestResponse) { 
%>using GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>;<%
} %><%
if(!namespaceRequestResponse) { 
%>using GuestBell.Common.<%= projectName %>.RequestResponse;<%
}%>
using GuestBell.Common.<%= projectName %>.Model;
using GuestBell.Common.Web.Model.<%= featureName %>;
using GuestBell.Common.Web.ViewModel.<%= featureName %>;

namespace GuestBell.Common.Web.Mapping
{
    public class <%= featureName %>Profile : Profile
    {
        public <%= featureName %>Profile()
        {
<% if(includeGet) { -%>
            CreateMap<<%= featureName %>DTO, <%= featureName %>WebDTO>();
<% } -%>
<% if(includePut) { -%>
            CreateMap<Put<%= featureName %>WebDTO, Put<%= featureName %>DTO>();
<% } -%>
<% if(includePost) { -%>
            CreateMap<Post<%= featureName %>WebDTO, Post<%= featureName %>DTO>();
<% } -%>
<% if(includeGet || includePut || includePost) { -%>

<% } -%>
<% if(includeDelete) { -%>
            CreateMap<Delete<%= featureName %>sResponseDTO, Delete<%= featureName %>sWebResponseDTO>();
            
<% } -%>
<% if(includeGet) { -%>
            CreateMap<Get<%= featureName %>sWebRequestDTO, Get<%= featureName %>sRequestDTO>();
            CreateMap<Get<%= featureName %>sResponseDTO, Get<%= featureName %>sWebResponseDTO>();

<% } -%>
<% if(includePost) { -%>
            CreateMap<Post<%= featureName %>sWebRequestDTO, Post<%= featureName %>sRequestDTO>();
            CreateMap<Post<%= featureName %>sResponseDTO, Post<%= featureName %>sWebResponseDTO>();

<% } -%>
<% if(includePut) { -%>
            CreateMap<Put<%= featureName %>sResponseDTO, Put<%= featureName %>sWebResponseDTO>();
            CreateMap<Put<%= featureName %>sWebRequestDTO, Put<%= featureName %>sRequestDTO>();
<% } -%>
        }
    }
}
