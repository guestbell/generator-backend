using AutoMapper;
using GuestBell.Common.Constant;
using GuestBell.Common.<%= projectName %>.Interface;
<%if(namespaceRequestResponse) { 
%>using GuestBell.Common.<%= projectName %>.RequestResponse.<%= featureName %>;<%
} else { 
%>using GuestBell.Common.<%= projectName %>.RequestResponse;<%
}%>
using GuestBell.Common.Permissions.Model.Constants;
using GuestBell.Common.Permissions.Model.Enum;
using GuestBell.Common.Role.Interface;
using GuestBell.Common.Tag.Interface;
using GuestBell.Common.Tag.Model;
using GuestBell.Common.Tag.Model.Enum;
using GuestBell.Common.Tag.RequestResponse;
using GuestBell.Common.Web.Base;
using GuestBell.Common.Web.Binder.Constants;
using GuestBell.Common.Web.Extension;
using GuestBell.Common.Web.Model.Tag;
using GuestBell.Common.Web.Util;
using GuestBell.Common.Web.ViewModel.<%= featureName %>;
using GuestBell.Host.Backend.Filter;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBell.Host.Backend.Controllers
{
    [Produces("application/json")]
<% if(isBoundToProperty) { -%> 
    [Route("property/{propertyId:long}/<%= featureName.toLowerCase() %>")]
<% } else { -%>
    [Route("<%= featureName.toLowerCase() %>")]
<% } -%>
    public class <%= featureName %>Controller : BaseController
    {
        private I<%= featureName %> property;
        private IMapper mapper;
        private ILogger logger;

        public <%= featureName %>Controller(I<%= featureName %> property, IMapper mapper, ILogger<<%= featureName %>Controller> logger)
        {
            this.property = property;
            this.mapper = mapper;
            this.logger = logger;
        }

<% if(includeGet) { -%>
        [Produces(typeof(Get<%= featureName %>sWebResponseDTO))]
        [HttpGet]
        public async Task<IActionResult> Get(<% if(isBoundToProperty) { %>[FromRoute, Required]long propertyId, <% } %>[FromQuery]Get<%= featureName %>sWebRequestDTO request)
        {
            return await Get(<% if(isBoundToProperty) { %>propertyId, <% } %>new long[] { }, request);
        }
        
<% } -%>
<% if(includeGet) { -%>
        [Produces(typeof(Get<%= featureName %>sWebResponseDTO))]
        [HttpGet("{ids:" + RouteArrayConstants.NUMBER_ARRAY + "}")]
        public async Task<IActionResult> Get(<% if(isBoundToProperty) { %>[FromRoute, Required]long propertyId, <% } %>[FromRoute, Required]long[] ids, [FromQuery]Get<%= featureName %>sWebRequestDTO request)
        {
            return await this.GenericWebRespond(async () =>
            {
                var pluginRequest = mapper.Map<Get<%= featureName %>sRequestDTO>(request);
                <% if(isBoundToProperty) { %>
                pluginRequest.PropertyId = propertyId;
                <% } %>
                pluginRequest.Ids = ids.ToList();
                var resp = await property.Get(pluginRequest);
                var webResp = mapper.Map<Get<%= featureName %>sWebResponseDTO>(resp);
                return webResp;
            }, ModelState, logger, LogEventIdConstant.GET_ITEM);
        }
        
<% } -%>
<% if(includePost) { -%>
        [Produces(typeof(Post<%= featureName %>sWebResponseDTO))]
        [HttpPost]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
<% if(isBoundToProperty) { %>
        [Permission(PermissionKeysConstant.<%= featureName.toUpperCase() %>_KEY, PermissionEnum.Post)]
<% } -%>
        public async Task<IActionResult> Post(<% if(isBoundToProperty) { %>[FromRoute, Required]long propertyId, <% } %>[FromBody, Required]Post<%= featureName %>sWebRequestDTO request)
        {
            return await this.GenericWebRespond(async () =>
            {
                var pluginRequest = mapper.Map<Post<%= featureName %>sRequestDTO>(request);
                <% if(isBoundToProperty) { %>
                pluginRequest.PropertyId = propertyId;
                <% } %>
                var resp = await property.Post(pluginRequest);
                var webResp = mapper.Map<Post<%= featureName %>sWebResponseDTO>(resp);
                return webResp;
            }, ModelState, logger, LogEventIdConstant.INSERT_ITEM);
        }
        
<% } -%>
<% if(includePut) { -%>
        [Produces(typeof(Put<%= featureName %>sWebResponseDTO))]
        [HttpPut]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
<% if(isBoundToProperty) { %>
        [Permission(PermissionKeysConstant.<%= featureName.toUpperCase() %>_KEY, PermissionEnum.Put)]
<% } -%>
        public async Task<IActionResult> Put(<% if(isBoundToProperty) { %>[FromRoute, Required]long propertyId, <% } %>[FromBody, Required]Put<%= featureName %>sWebRequestDTO request)
        {
            return await this.GenericWebRespond(async () =>
            {
                var pluginRequest = mapper.Map<Put<%= featureName %>sRequestDTO>(request);
                <% if(isBoundToProperty) { %>
                pluginRequest.PropertyId = propertyId;
                <% } %>
                var resp = await property.Put(pluginRequest);
                var webResp = mapper.Map<Put<%= featureName %>sWebResponseDTO>(resp);
                return webResp;
            }, ModelState, logger, LogEventIdConstant.UPDATE_ITEM);
        }
<% } -%>
<% if(includeDelete) { -%>
        [Produces(typeof(Delete<%= featureName %>sWebResponseDTO))]
        [HttpDelete("{ids:" + RouteArrayConstants.NUMBER_ARRAY + "}")]
        [Authorize(AuthenticationSchemes = IdentityServerAuthenticationDefaults.AuthenticationScheme)]
<% if(isBoundToProperty) { %>
        [Permission(PermissionKeysConstant.<%= featureName.toUpperCase() %>_KEY, PermissionEnum.Delete)]
<% } -%>
        public async Task<IActionResult> Delete(<% if(isBoundToProperty) { %>[FromRoute, Required]long propertyId, <% } %>[FromRoute, Required]long[] ids)
        {
            return await this.GenericWebRespond(async () =>
            {
                var pluginRequest = new Delete<%= featureName %>sRequestDTO();
                <% if(isBoundToProperty) { %>
                pluginRequest.PropertyId = propertyId;
                <% } %>
                pluginRequest.Ids = ids.ToList();
                var resp = await property.Delete(pluginRequest);
                var webResp = mapper.Map<Delete<%= featureName %>sWebResponseDTO>(resp);
                return webResp;
            }, ModelState, logger, LogEventIdConstant.DELETE_ITEM);
        }
<% } -%>
    }
}