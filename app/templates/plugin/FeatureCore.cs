using AutoMapper;
using GuestBell.Common.<%= projectName %>.Interface;
<%if(namespaceRequestResponse) { 
%>using GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>;<%
} %><%
if(!namespaceRequestResponse) { 
%>using GuestBell.Common.<%= projectName %>.RequestResponse;<%
}%>
using GuestBell.Common.Plugin.Util;
using GuestBell.Dal.<%= projectName %>.Interface;
<%if(namespaceRequestResponse) { 
%>using GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>;<%
} %><%
if(!namespaceRequestResponse) { 
%>using GuestBell.Dal.<%= projectName %>.RequestResponse;<%
}%>
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace GuestBell.Plugin.<%= projectName %>
{
    public class <%= featureName %>Core : I<%= featureName %>
    {
        private readonly <%= featureName %>ConfigDTO config;
        private readonly ILogger logger;
        private readonly IServiceProvider serviceProvider;
        private readonly IMapper mapper;
        private readonly I<%= featureName %>Dal dal;

        public <%= featureName %>Core(ILogger<<%= featureName %>Core> logger, I<%= featureName %>Dal dal, IMapper mapper,
            IServiceProvider serviceProvider, IOptionsSnapshot<<%= featureName %>ConfigDTO> config)
        {
            this.config = config.Value;
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            this.mapper = mapper;
            this.dal = dal;
        }

<% if(includeGet) { -%>
        public async Task<Get<%= featureName %>sResponseDTO> Get(Get<%= featureName %>sRequestDTO request)
        {
            return await request.GenericPluginRespond(async (safeRequest) =>
            {
                var sqlReq = mapper.Map<Get<%= featureName %>sSqlRequestDTO>(safeRequest);
                var sqlResp = await dal.Get(sqlReq);
                var resp = mapper.Map<Get<%= featureName %>sResponseDTO>(sqlResp);
                return resp;
            }, logger, nameof(Get));
        }
        
<% } -%>
<% if(includePost) { -%>
        public async Task<Post<%= featureName %>sResponseDTO> Post(Post<%= featureName %>sRequestDTO request)
        {
            return await request.GenericPluginRespond(async (safeRequest) =>
            {
                var sqlReq = mapper.Map<Post<%= featureName %>sSqlRequestDTO>(safeRequest);
                var sqlResp = await dal.Post(sqlReq);
                var resp = mapper.Map<Post<%= featureName %>sResponseDTO>(sqlResp);
                return resp;
            }, logger, nameof(Post));
        }
        
<% } -%>
<% if(includePut) { -%>
        public async Task<Put<%= featureName %>sResponseDTO> Put(Put<%= featureName %>sRequestDTO request)
        {
            return await request.GenericPluginRespond(async (safeRequest) =>
            {
                var sqlReq = mapper.Map<Put<%= featureName %>sSqlRequestDTO>(safeRequest);
                var sqlResp = await dal.Put(sqlReq);
                var resp = mapper.Map<Put<%= featureName %>sResponseDTO>(sqlResp);
                return resp;
            }, logger, nameof(Put));
        }
        
<% } -%>
<% if(includeDelete) { -%>
        public async Task<Delete<%= featureName %>sResponseDTO> Delete(Delete<%= featureName %>sRequestDTO request)
        {
            return await request.GenericPluginRespond(async (safeRequest) =>
            {
                var sqlReq = mapper.Map<Delete<%= featureName %>sSqlRequestDTO>(safeRequest);
                var sqlResp = await dal.Delete(sqlReq);
                var resp = mapper.Map<Delete<%= featureName %>sResponseDTO>(sqlResp);
                return resp;
            }, logger, nameof(Delete));
        }
<% } -%>
    }
}
