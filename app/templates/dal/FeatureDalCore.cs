using Dapper;
using GuestBell.Common.Dal.Base;
using GuestBell.Common.Dal.Util;
using GuestBell.Common.Enum;
using GuestBell.Dal.<%= projectName %>.Interface;
using GuestBell.Dal.<%= projectName %>.Model;
<%if(namespaceRequestResponse) { -%>
using GuestBell.Dal.<%= projectName %>.RequestResponse.<%= featureName %>;
<% } else { -%>
using GuestBell.Dal.<%= projectName %>.RequestResponse;
<% } -%>
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBell.Dal.<%= projectName %>
{
    public class <%= featureName %>DalCore : I<%= featureName %>Dal
    {
        private ILogger<<%= featureName %>DalCore>logger;
        private <%= featureName %>DalConfigDTO config;

        public <%= featureName %>DalCore(ILogger<<%= featureName %>DalCore>logger, IOptionsSnapshot<<%= featureName %>DalConfigDTO>config)
        {
            this.logger = logger;
            this.config = config.Value;
        }

<% if(includeDelete) { -%>
        public async Task<Delete<%= featureName %>sSqlResponseDTO>Delete(Delete<%= featureName %>sSqlRequestDTO request)
        {
            return await request.GenericDalRespond(config, async (reqSafe, connection, transaction) =>
            {
                var p = new DynamicParameters();
                if (reqSafe.Ids != null)
                {
                    var ids = new DataTable();
                    ids.Columns.Add("Id", typeof(long));
                    foreach (var id in reqSafe.Ids)
                    {
                        ids.Rows.Add(id);
                    }
                    p.Add("@Ids", ids.AsTableValuedParameter("dbo.IdList"));
                }
<%if (isBoundToProperty) { -%>
                p.Add("@PropertyId", reqSafe.PropertyId);
<% } -%>
                p.Add("@Revert", reqSafe.Revert);
                p.Add("@Return", dbType: DbType.Int32, direction: ParameterDirection.Output);

                await connection.ExecuteAsync("[<%= featureName %>].spDelete<%= featureName %>s", p, transaction: transaction, commandType: CommandType.StoredProcedure);
                var resp = reqSafe.GetResponse<Delete<%= featureName %>sSqlResponseDTO>();
                var ret = p.Get<int>("@Return");
                resp.Status = ret == 0 ? OperationStatusEnum.Success : OperationStatusEnum.Failure;
                return resp;
            }, logger, nameof(Delete));
        }
<% } -%>
<% if(includeDelete && (includeGet || includePost || includePut)) { -%>

<% } -%>
<% if(includeGet && isPaginated) { -%>
        public async Task<Get<%= featureName %>sSqlResponseDTO>Get(Get<%= featureName %>sSqlRequestDTO request)
        {
            return await request.GenericDalRespond(config, async (reqSafe, connection, transaction) =>
            {
                var p = new DynamicParameters();
                if (reqSafe.Ids != null)
                {
                    var ids = new DataTable();
                    ids.Columns.Add("Id", typeof(long));
                    foreach (var id in reqSafe.Ids)
                    {
                        ids.Rows.Add(id);
                    }
                    p.Add("@Ids", ids.AsTableValuedParameter("dbo.IdList"));
                }
<%if (isBoundToProperty) { -%>
                p.Add("@PropertyId", reqSafe.PropertyId);
<% } -%>
                p.AddPaginationParameters(reqSafe);

                p.Add("@Return", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var lookup = new Dictionary<long, <%= featureName %>SqlDTO>();

                var reader = await connection.QueryMultipleAsync("[<%= featureName %>].spGet<%= featureName %>s", p, transaction: transaction, commandType: CommandType.StoredProcedure);

                long totalCount = 0;
                reader.Read<<%= featureName %>SqlDTO, long, <%= featureName %>SqlDTO>((<%= featureName %>, totalCountLocal) => {
                    totalCount = totalCountLocal;
                    lookup.Add(<%= featureName %>.Id, <%= featureName %>);
                    return <%= featureName %>;
                }, splitOn: "TotalCount");

                var ret = p.Get<int>("@Return");
                var resp = reqSafe.GetResponse<Get<%= featureName %>sSqlResponseDTO>();
                resp.<%= featureName %>s = new PaginatedDataSqlDTO<<%= featureName %>SqlDTO>()
                {
                    Page = reqSafe.Page,
                    Count = reqSafe.Count,
                    Items = lookup.Values.ToList(),
                    TotalCount = totalCount,
                    TotalPages = (int)Math.Ceiling((double)totalCount / (reqSafe.Count))
                };
                resp.Status = ret == 0 ? OperationStatusEnum.Success : OperationStatusEnum.Failure;
                return resp;
            }, logger, nameof(Get));
        }
<% } -%>
<% if(includeGet && !isPaginated) { -%>
        public async Task<Get<%= featureName %>sSqlResponseDTO>Get(Get<%= featureName %>sSqlRequestDTO request)
        {
            return await request.GenericDalRespond(config, async (reqSafe, connection, transaction) =>
            {
                var p = new DynamicParameters();
                if (reqSafe.Ids != null)
                {
                    var ids = new DataTable();
                    ids.Columns.Add("Id", typeof(long));
                    foreach (var id in reqSafe.Ids)
                    {
                        ids.Rows.Add(id);
                    }
                    p.Add("@Ids", ids.AsTableValuedParameter("dbo.IdList"));
                }
<%if (isBoundToProperty) { -%>
                p.Add("@PropertyId", reqSafe.PropertyId);
<% } -%>
                p.Add("@Return", dbType: DbType.Int32, direction: ParameterDirection.Output);

                var items = await connection.QueryAsync<<%= featureName %>SqlDTO>("[<%= featureName %>].spGet<%= featureName %>s", p, transaction: transaction, commandType: CommandType.StoredProcedure);

                var ret = p.Get<int>("@Return");
                var resp = reqSafe.GetResponse<Get<%= featureName %>sSqlResponseDTO >();
                resp.<%= featureName %>s = items.ToList();
                resp.Status = ret == 0 ? OperationStatusEnum.Success : OperationStatusEnum.Failure;
                return resp;
            }, logger, nameof(Get));
        }
<% } -%>
<% if(includeGet && (includePost || includePut)) { -%>

<% } -%>
<% if(includePost) { -%>
        public async Task<Post<%= featureName %>sSqlResponseDTO>Post(Post<%= featureName %>sSqlRequestDTO request)
        {
            return await request.GenericDalRespond(config, async (reqSafe, connection, transaction) =>
            {
                var parameters = new List<DynamicParameters>();
                foreach (var <%= featureName %> in reqSafe.<%= featureName %>s)
                {
                    var p = new DynamicParameters();
                    // Put more stuff here
<%if (isBoundToProperty) { -%>
                    p.Add("@PropertyId", reqSafe.PropertyId);
<% } -%>
                    p.Add("@Id", dbType: DbType.Int64, direction: ParameterDirection.Output);
                    p.Add("@Return", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    parameters.Add(p);
                }
                await connection.ExecuteAsync("[<%= featureName %>].spPost<%= featureName %>", parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                var resp = reqSafe.GetResponse<Post<%= featureName %>sSqlResponseDTO>();
                var rets = parameters.Select(item =>item.Get<int>("@Return")).ToList();
                resp.Ids = parameters.Select(item =>item.Get<long>("@Id")).ToList();
                resp.Status = resp.Ids.Count == reqSafe.<%= featureName %>s.Count && rets.All(item =>item >= 0) ? OperationStatusEnum.Success : OperationStatusEnum.Failure;
                // Add status
                return resp;
          }, logger, nameof(Post));
        }
<% } -%>
<% if(includePost && includePut) { -%>

<% } -%>
<% if(includePut) { -%>
        public async Task<Put<%= featureName %>sSqlResponseDTO>Put(Put<%= featureName %>sSqlRequestDTO request)
        {
            return await request.GenericDalRespond(config, async (reqSafe, connection, transaction) =>
            {
                var parameters = new List<DynamicParameters>();
                foreach (var <%= featureName %> in reqSafe.<%= featureName %>s)
                {
                    var p = new DynamicParameters();
                    // Put more stuff here
<%if (isBoundToProperty) { -%>
                    p.Add("@PropertyId", reqSafe.PropertyId);
<% } -%>
                    p.Add("@Id", <%= featureName %>.Id);
                    p.Add("@Return", dbType: DbType.Int32, direction: ParameterDirection.Output);
                    parameters.Add(p);
                }
                await connection.ExecuteAsync("[<%= featureName %>].spPut<%= featureName %>", parameters, transaction: transaction, commandType: CommandType.StoredProcedure);
                var resp = reqSafe.GetResponse<Put<%= featureName %>sSqlResponseDTO >();
                var rets = parameters.Select(item =>item.Get<int>("@Return")).ToList();
                resp.Status = rets.Count == reqSafe.<%= featureName %>s.Count && rets.All(item =>item == 0) ? OperationStatusEnum.Success : OperationStatusEnum.Failure;
                // Add status
                return resp;
            }, logger, nameof(Put));
        }
<% } -%>
    }
}