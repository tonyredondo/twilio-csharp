using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Twilio.Base;
using Twilio.Clients;
using Twilio.Converters;
using Twilio.Exceptions;
using Twilio.Http;
using Twilio.Types;

namespace Twilio.Rest.Pricing.V1.Voice 
{

    public class CountryResource : Resource 
    {
        private static Request BuildReadRequest(ReadCountryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Pricing,
                "/v1/Voice/Countries",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<CountryResource> Read(ReadCountryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildReadRequest(options, client));
            
            var page = Page<CountryResource>.FromJson("countries", response.Content);
            return new ResourceSet<CountryResource>(page, options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<CountryResource>> ReadAsync(ReadCountryOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// read
        /// </summary>
        public static ResourceSet<CountryResource> Read(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCountryOptions{PageSize = pageSize, Limit = limit};
            return Read(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<ResourceSet<CountryResource>> ReadAsync(int? pageSize = null, long? limit = null, ITwilioRestClient client = null)
        {
            var options = new ReadCountryOptions{PageSize = pageSize, Limit = limit};
            var response = await System.Threading.Tasks.Task.FromResult(Read(options, client));
            return response;
        }
        #endif
    
        public static Page<CountryResource> NextPage(Page<CountryResource> page, ITwilioRestClient client)
        {
            var request = new Request(
                HttpMethod.Get,
                page.GetNextPageUrl(
                    Rest.Domain.Pricing,
                    client.Region
                )
            );
            
            var response = client.Request(request);
            return Page<CountryResource>.FromJson("countries", response.Content);
        }
    
        private static Request BuildFetchRequest(FetchCountryOptions options, ITwilioRestClient client)
        {
            return new Request(
                HttpMethod.Get,
                Rest.Domain.Pricing,
                "/v1/Voice/Countries/" + options.IsoCountry + "",
                client.Region,
                queryParams: options.GetParams()
            );
        }
    
        /// <summary>
        /// fetch
        /// </summary>
        public static CountryResource Fetch(FetchCountryOptions options, ITwilioRestClient client = null)
        {
            client = client ?? TwilioClient.GetRestClient();
            var response = client.Request(BuildFetchRequest(options, client));
            return FromJson(response.Content);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CountryResource> FetchAsync(FetchCountryOptions options, ITwilioRestClient client)
        {
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// fetch
        /// </summary>
        public static CountryResource Fetch(string isoCountry, ITwilioRestClient client = null)
        {
            var options = new FetchCountryOptions(isoCountry);
            return Fetch(options, client);
        }
    
        #if NET40
        public static async System.Threading.Tasks.Task<CountryResource> FetchAsync(string isoCountry, ITwilioRestClient client = null)
        {
            var options = new FetchCountryOptions(isoCountry);
            var response = await System.Threading.Tasks.Task.FromResult(Fetch(options, client));
            return response;
        }
        #endif
    
        /// <summary>
        /// Converts a JSON string into a CountryResource object
        /// </summary>
        ///
        /// <param name="json"> Raw JSON string </param>
        /// <returns> CountryResource object represented by the provided JSON </returns> 
        public static CountryResource FromJson(string json)
        {
            // Convert all checked exceptions to Runtime
            try
            {
                return JsonConvert.DeserializeObject<CountryResource>(json);
            }
            catch (JsonException e)
            {
                throw new ApiException(e.Message, e);
            }
        }
    
        [JsonProperty("country")]
        public string Country { get; private set; }
        [JsonProperty("iso_country")]
        public string IsoCountry { get; private set; }
        [JsonProperty("outbound_prefix_prices")]
        public List<OutboundPrefixPrice> OutboundPrefixPrices { get; private set; }
        [JsonProperty("inbound_call_prices")]
        public List<InboundCallPrice> InboundCallPrices { get; private set; }
        [JsonProperty("price_unit")]
        public string PriceUnit { get; private set; }
        [JsonProperty("url")]
        public Uri Url { get; private set; }
    
        private CountryResource()
        {
        
        }
    }

}