namespace AuctionServiceClientDesktop.Servicelayer
{
    public abstract class ServiceConnection
    {

        private readonly HttpClient _httpEnabler;

        public ServiceConnection(string inBaseUrl)
        {
            _httpEnabler = new HttpClient();
            BaseUrl = inBaseUrl;
            UseUrl = BaseUrl;
        }

        public string? BaseUrl { get; init; }
        public string? UseUrl { get; set; }

        public async Task<HttpResponseMessage?> CallServiceGet()
        {
            HttpResponseMessage? hrm = null;
            if (UseUrl != null)
            {
                hrm = await _httpEnabler.GetAsync(UseUrl);
            }
            return hrm;
        }

        public async Task<HttpResponseMessage?> CallServicePost(StringContent postJson)
        {
            HttpResponseMessage? hrm = null;
            if (UseUrl != null)
            {
                hrm = await _httpEnabler.PostAsync(UseUrl, postJson);
            }
            return hrm;
        }
        public Task<HttpResponseMessage?> CallServicePut(StringContent postJson)
        {
            throw new NotImplementedException();
        }
        public Task<HttpResponseMessage?> CallServiceDelete()
        {
            throw new NotImplementedException();
        }
    }
}
