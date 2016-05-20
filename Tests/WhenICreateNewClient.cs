using System;
using System.Diagnostics;
using System.Net.Http;
using FluentAssertions;
using ProtobuffPrototype.Models;
using ProtobuffPrototype.Models.Request;
using ProtobuffPrototype.Models.Response;
using Service;
using Xunit;

namespace Tests
{
    public class WhenICreateNewClient
    {
        private ServiceClient _client;
        private CreateClientRequest createClientRequest;

        public WhenICreateNewClient()
        {
            createClientRequest = new CreateClientRequest
            {
                Client = new ClientModel
                {
                    CompanyId = 1,
                    Created = DateTime.UtcNow,
                    Email = "sample@domain.com",
                    FirstName = "First",
                    LastName = "Last",
                    Logon = "NewUser",
                    MiddleName = "OI",
                    Password = "QWERTYUIOP00",
                },
                Value1 = "1",
                Value2 = "2",
                Value3 = "3"
            };
        }

        [Theory]
        //[InlineData(ServiceClient.Formatters.JSon)]
        [InlineData(ServiceClient.Formatters.Protobuf)]
        public void ShouldCreateSuccessfullyClient(ServiceClient.Formatters formatter)
        {
            var timer = Stopwatch.StartNew();
            for (int i = 0; i < 10; i++)
            {
                _client = new ServiceClient(formatter);

                var response = _client
                    .Post<CreateClientRequest, CreateClientResponse>("http://localhost:34098/api/client",
                        createClientRequest).Result;
            }
            timer.Stop();
            Debug.WriteLine("Formatter: {0}, elapsed time: {1} ms", formatter, timer.ElapsedMilliseconds/10);
        }
    }
}
