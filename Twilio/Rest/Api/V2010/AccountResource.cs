using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Api.V2010 
{

    public class AccountResource : Resource 
    {
        public sealed class StatusEnum : StringEnum 
        {
            private StatusEnum(string value) : base(value) {}
            public StatusEnum() {}
        
            public static readonly StatusEnum Active = new StatusEnum("active");
            public static readonly StatusEnum Suspended = new StatusEnum("suspended");
            public static readonly StatusEnum Closed = new StatusEnum("closed");
        }
    
        public sealed class TypeEnum : StringEnum 
        {
            private TypeEnum(string value) : base(value) {}
            public TypeEnum() {}
        
            public static readonly TypeEnum Trial = new TypeEnum("Trial");
            public static readonly TypeEnum Full = new TypeEnum("Full");
        }
    
        private static Request BuildCreateRequest(CreateAccountOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts.json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Create a new Twilio Subaccount from the account making the request
        /// </summary>
        public static AccountResource Create(CreateAccountOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildCreateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AccountResource> CreateAsync(CreateAccountOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Create a new Twilio Subaccount from the account making the request
        /// </summary>
        public static AccountResource Create(string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new CreateAccountOptions{FriendlyName = friendlyName};
            return Create(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AccountResource> CreateAsync(string friendlyName = null, ITwilioRestClient client = null)
        {
            var options = new CreateAccountOptions{FriendlyName = friendlyName};
            var response = await System.Threading.Tasks.Task.FromResult(Create(options, client));
            return response;
        }
        #endif
    
        private static Request BuildFetchRequest(FetchAccountOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.Sid ?? client.AccountSid) + ".json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Fetch the account specified by the provided Account Sid
        /// </summary>
        public static AccountResource Fetch(FetchAccountOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AccountResource> FetchAsync(FetchAccountOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Fetch the account specified by the provided Account Sid
        /// </summary>
        public static AccountResource Fetch(string sid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAccountOptions{Sid = sid};
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AccountResource> FetchAsync(string sid = null, ITwilioRestClient client = null)
        {
            var options = new FetchAccountOptions{Sid = sid};
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        private static Request BuildReadRequest(ReadAccountOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Api,
                "/2010-04-01/Accounts.json",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Retrieves a collection of Accounts belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<AccountResource> Read(ReadAccountOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<AccountResource>.FromJson("accounts", response.Content);
            return new ResourceSet<AccountResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<AccountResource>> ReadAsync(ReadAccountOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Retrieves a collection of Accounts belonging to the account used to make the request
        /// </summary>
        public static ResourceSet<AccountResource> Read(string friendlyName = null, AccountResource.StatusEnum status = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAccountOptions{FriendlyName = friendlyName, Status = status, PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<AccountResource>> ReadAsync(string friendlyName = null, AccountResource.StatusEnum status = null, int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadAccountOptions{FriendlyName = friendlyName, Status = status, PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<AccountResource> NextPage(Page<AccountResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Api,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<AccountResource>.FromJson("accounts", response.Content);
        }
    
        private static Request BuildUpdateRequest(UpdateAccountOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Post,
                Rest.Domain.Api,
                "/2010-04-01/Accounts/" + (options.Sid ?? client.AccountSid) + ".json",
                client.Region,
                postParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// Modify the properties of a given Account
        /// </summary>
        public static AccountResource Update(UpdateAccountOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildUpdateRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AccountResource> UpdateAsync(UpdateAccountOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Modify the properties of a given Account
        /// </summary>
        public static AccountResource Update(string sid = null, string friendlyName = null, AccountResource.StatusEnum status = null, ITwilioRestClient client = null)
        {
            var options = new UpdateAccountOptions{Sid = sid, FriendlyName = friendlyName, Status = status};
            return Update(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<AccountResource> UpdateAsync(string sid = null, string friendlyName = null, AccountResource.StatusEnum status = null, ITwilioRestClient client = null)
        {
            var options = new UpdateAccountOptions{Sid = sid, FriendlyName = friendlyName, Status = status};
            var response = await System.Threading.Tasks.Task.FromResult(Update(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a AccountResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> AccountResource object represented by the provided JSON </returns> 
        public static AccountResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<AccountResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("auth_token")]
        public string AuthToken { get; private set; }
        [JsonProperty("date_created")]
        public DateTime? DateCreated { get; private set; }
        [JsonProperty("date_updated")]
        public DateTime? DateUpdated { get; private set; }
        [JsonProperty("friendly_name")]
        public string FriendlyName { get; private set; }
        [JsonProperty("owner_account_sid")]
        public string OwnerAccountSid { get; private set; }
        [JsonProperty("sid")]
        public string Sid { get; private set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountResource.StatusEnum Status { get; private set; }
        [JsonProperty("subresource_uris")]
        public Dictionary<string, string> SubresourceUris { get; private set; }
        [JsonProperty("type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public AccountResource.TypeEnum Type { get; private set; }
        [JsonProperty("uri")]
        public string Uri { get; private set; }
    
        private AccountResource()
        {
        
        }
    }

}