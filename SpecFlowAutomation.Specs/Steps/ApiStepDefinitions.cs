using System;
using FluentAssertions;
using RestSharp;
using SpecFlowAutomation.Specs.Drivers;

namespace SpecFlowAutomation.Specs.Steps
{
    [Binding]
    public class ApiStepDefinitions : BrowserDriver
    {
        private Api _api = new();

        [Given(@"The user set base url as : (.*)")]
        public void GivenTheUserSetBaseUrlAs(string baseUrl)
        {
            _api.baseUrl = baseUrl;
        }

        [Given(@"The user should see the response (.*)")]
        public void GivenTheUserShouldSeeTheResponse(int expectedCode)
        {
            if (_api.restResponse != null)
            {
                var responseCode = (int) _api.restResponse.StatusCode;
                responseCode.Should().Be(expectedCode);
            }
        }

        [Given(@"The user sends get request to (.*)")]
        public void GivenTheUserSendsGetRequestWithRestsharpToVTime(string endPoint)
        {
            _api.endPoint = endPoint;
            _api.GetRequest(_api.endPoint);
        }

        [Given(@"The user sends delete request to (.*)")]
        public void GivenTheUserSendsDeleteRequestToApiVApi_Key(string endpoint)
        {
            _api.endPoint = endpoint;
            _api.DelRequest(_api.endPoint, _api.authHeaders);
        }

        [Given(@"The user sends post request to /user/createWithArray")]
        public void GivenTheUserSendsPostRequestToUserCreateWithArray()
        {
            _api.endPoint = "/user/createWithArray";

            _api.restClient = new RestClient(_api.baseUrl ?? throw new InvalidOperationException());
            _api.restRequest = new RestRequest(_api.endPoint, Method.Post);

            var body = @"
                        [
                          {
                            ""id"": 0,
                            ""username"": ""specflowkurtulus"",
                            ""firstName"": ""kurtulus"",
                            ""lastName"": ""akkaya"",
                            ""email"": ""akkaya@mail.com"",
                            ""password"": ""password"",
                            ""phone"": ""phone"",
                            ""userStatus"": 0
                          }
                        ]
                        ";
            _api.restRequest.AddParameter("application/json", body, ParameterType.RequestBody);

            _api.restResponse = _api.restClient.ExecutePostAsync(_api.restRequest).GetAwaiter().GetResult();
            _api.responseString = _api.restResponse.Content;
        }

        [Given(@"The user sends put request to /user/specflowkurtulus")]
        public void GivenTheUserSendsPutRequestToUserKurtulusakkaya()
        {
            _api.endPoint = "/user/specflowkurtulus";

            _api.restClient = new RestClient(_api.baseUrl ?? throw new InvalidOperationException());
            _api.restRequest = new RestRequest(_api.endPoint, Method.Put);

            var body = @"
                          {
                            ""id"": 0,
                            ""username"": ""specflowkurtulus"",
                            ""firstName"": ""kurtulus mehmet"",
                            ""lastName"": ""akkaya"",
                            ""email"": ""akkaya@mail.com"",
                            ""password"": ""password"",
                            ""phone"": ""phone"",
                            ""userStatus"": 0
                          }
                        ";
            _api.restRequest.AddParameter("application/json", body, ParameterType.RequestBody);

            _api.restResponse = _api.restClient.ExecutePutAsync(_api.restRequest).GetAwaiter().GetResult();
            _api.responseString = _api.restResponse.Content;
        }
    }
}