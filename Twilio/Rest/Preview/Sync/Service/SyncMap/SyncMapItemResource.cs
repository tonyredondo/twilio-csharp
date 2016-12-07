using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Preview.Sync.Service.SyncMap 
{

    public class SyncMapItemResource : Resource 
    {
        public sealed class QueryResultOrderEnum : StringEnum 
        {
            private QueryResultOrderEnum(string value) : base(value) {}
            public QueryResultOrderEnum() {}
        
            public static readonly QueryResultOrderEnum Asc = new QueryResultOrderEnum("asc");
            public static readonly QueryResultOrderEnum Desc = new QueryResultOrderEnum("desc");
        }
    
        public sealed class QueryFromBoundTypeEnum : StringEnum 
        {
            private QueryFromBoundTypeEnum(string value) : base(value) {}
            public QueryFromBoundTypeEnum() {}
        
            public static readonly QueryFromBoundTypeEnum Inclusive = new QueryFromBoundTypeEnum("inclusive");
            public static readonly QueryFromBoundTypeEnum Exclusive = new QueryFromBoundTypeEnum("exclusive");
        }
    
        private static Request BuildFetchRequest(FetchSyncMapItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Items/" + options.Key + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static SyncMapItemResource Fetch(FetchSyncMapItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncMapItemResource> FetchAsync(FetchSyncMapItemOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static SyncMapItemResource Fetch(string serviceSid, string mapSid, string key, ITwilioRestClient client = null)
        {
            var options = new FetchSyncMapItemOptions(serviceSid, mapSid, key);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncMapItemResource> FetchAsync(string serviceSid, string mapSid, string key, ITwilioRestClient client = null)
        {
            var options = new FetchSyncMapItemOptions(serviceSid, mapSid, key);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildDeleteRequest(DeleteSyncMapItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Delete,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Items/" + options.Key + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(DeleteSyncMapItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildDeleteRequest(options, client));
            return response.StatusCode == System.Net.HttpStatusCode.NoContent;
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(DeleteSyncMapItemOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// delete
        /// </summary>
        public static bool Delete(string serviceSid, string mapSid, string key, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncMapItemOptions(serviceSid, mapSid, key);
            return Delete(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<bool> DeleteAsync(string serviceSid, string mapSid, string key, ITwilioRestClient client = null)
        {
            var options = new DeleteSyncMapItemOptions(serviceSid, mapSid, key);
            var response = await System.Threading.Tasks.Task.FromResult(Delete(options, client));
            return response;
        }
        #endif
    
        private static Request BuildCreateRequest(CreateSyncMapItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Items",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// create
        /// </summary>
        public static SyncMapItemResource Create(CreateSyncMapItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncMapItemResource> CreateAsync(CreateSyncMapItemOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// create
        /// </summary>
        public static SyncMapItemResource Create(string serviceSid, string mapSid, string key, Object data, ITwilioRestClient client = null)
        {
            var options = new CreateSyncMapItemOptions(serviceSid, mapSid, key, data);
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncMapItemResource> CreateAsync(string serviceSid, string mapSid, string key, Object data, ITwilioRestClient client = null)
        {
            var options = new CreateSyncMapItemOptions(serviceSid, mapSid, key, data);
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadSyncMapItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Items",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<SyncMapItemResource> Read(ReadSyncMapItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<SyncMapItemResource>.FromJson("items", response.Content);
            return new ResourceSet<SyncMapItemResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<SyncMapItemResource>> ReadAsync(ReadSyncMapItemOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<SyncMapItemResource> Read(string serviceSid, string mapSid, SyncMapItemResource.QueryResultOrderEnum order = null, string from = null, SyncMapItemResource.QueryFromBoundTypeEnum bounds = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSyncMapItemOptions(serviceSid, mapSid){Order = order, From = from, Bounds = bounds, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<SyncMapItemResource>> ReadAsync(string serviceSid, string mapSid, SyncMapItemResource.QueryResultOrderEnum order = null, string from = null, SyncMapItemResource.QueryFromBoundTypeEnum bounds = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadSyncMapItemOptions(serviceSid, mapSid){Order = order, From = from, Bounds = bounds, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<SyncMapItemResource> NextPage(Page<SyncMapItemResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Preview,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<SyncMapItemResource>.FromJson("items", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateSyncMapItemOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Preview,
                "/Sync/Services/" + options.ServiceSid + "/Maps/" + options.MapSid + "/Items/" + options.Key + "",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// update
        /// </summary>
        public static SyncMapItemResource Update(UpdateSyncMapItemOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncMapItemResource> UpdateAsync(UpdateSyncMapItemOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// update
        /// </summary>
        public static SyncMapItemResource Update(string serviceSid, string mapSid, string key, Object data, ITwilioRestClient client = null)
        {
            var options = new UpdateSyncMapItemOptions(serviceSid, mapSid, key, data);
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<SyncMapItemResource> UpdateAsync(string serviceSid, string mapSid, string key, Object data, ITwilioRestClient client = null)
        {
            var options = new UpdateSyncMapItemOptions(serviceSid, mapSid, key, data);
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a SyncMapItemResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> SyncMapItemResource object represented by the provided JSON </returns> 
        public static SyncMapItemResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<SyncMapItemResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("key")]
        public string Key { get; private set; }
        [JsonProperty("account_sid")]
        public string AccountSid { get; private set; }
        [JsonProperty("service_sid")]
        public string ServiceSid { get; private set; }
        [JsonProperty("map_sid")]
        public string MapSid { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
        [JsonProperty("revision")]
        public string Revision { get; private set; }
        [JsonProperty("data")]
        public Object Data { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("created_by")]
        public string CreatedBy { get; private set; }
    
        private SyncMapItemResource()
        {
        
        }
    }

}