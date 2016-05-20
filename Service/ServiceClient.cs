using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using ProtoBuf;
using System.Threading.Tasks;
using WebApiContrib.Formatting;

namespace Service
{
    public class ServiceClient
    {
        public MediaTypeFormatter[] ReadFormatters { get; protected set; }
        public MediaTypeFormatter WriteFormatter { get; protected set; }
        private Formatters _formatter = Formatters.JSon;
        private HttpClient _client;

        public Formatters Formatter
        {
            get { return _formatter; }
            set
            {
                _formatter = value;
                if (value == Formatters.JSon)
                {
                    WriteFormatter = new JsonMediaTypeFormatter();
                }
                else if (value == Formatters.Protobuf)
                {
                    WriteFormatter = new ProtoBufFormatter();
                }
            }
        }

        public enum Formatters
        {
            JSon,
            Protobuf
        }

        public ServiceClient() : this(Formatters.JSon) { }

        public ServiceClient(Formatters formatter)
        {
            Formatter = formatter;
        }

        public virtual Task<TResponse> Post<TRequest, TResponse>(string url, TRequest request)
        {
            _client = new HttpClient { BaseAddress = new Uri(url) };
            var response = _client.PostAsync(url, request, WriteFormatter).Result;

            if (Formatter == Formatters.JSon)
            {
                if (ReadFormatters == null || ReadFormatters.Length == 0) return response.Content.ReadAsAsync<TResponse>();
                return response.Content.ReadAsAsync<TResponse>(ReadFormatters);
            }
            else // if (Formatter == Formatters.Protobuf)
            {
                var responseBody = response.Content.ReadAsStreamAsync().Result;
                responseBody.Position = 0;
                var results = Serializer.Deserialize<TResponse>(responseBody);
                return Task.FromResult(results);
            }
        }
    }
}
