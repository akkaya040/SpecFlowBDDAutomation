using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace SpecFlowAutomation.Specs.Drivers;

public class Api
{
    public RestClient? restClient { get; set; }
    public RestRequest? restRequest { get; set; }
    public RestResponse? restResponse { get; set; }
    public string? baseUrl { get; set; }
    public string? endPoint { get; set; }
    public string? responseString { get; set; }

    public string? apiAuthToken { get; set; }
    public string? apiCsrfToken { get; set; }

    public Dictionary<string, string> authHeaders = new Dictionary<string, string>();

    public RestResponse GetRequest(string endP, Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Get);
        restRequest.AddHeader("Content-Type", "application/json");
        restRequest.AddHeader("Accept", "application/json");

        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }

        restResponse = restClient.ExecuteGetAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;

        return restResponse;
    }

    public RestResponse PostRequest(string endP, string? body = null,
        Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Post);

        restRequest.AddHeader("Content-Type", "application/json;charset=utf-8");
        restRequest.AddHeader("Accept", "*/*");
        restRequest.AddHeader("Connection", "keep-alive");
        restRequest.AddHeader("Accept-Encoding", "gzip, deflate, br");

        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }

        if (body != null)
        {
            restRequest.AddParameter("application/json; charset=utf-8", JsonConvert.SerializeObject(body),
                ParameterType.RequestBody);
        }

        restResponse = restClient.ExecutePostAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;
        return restResponse;
    }

    public RestResponse PostRequest(string endP, Dictionary<string, string>? body = null,
        Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Post);

        restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
        restRequest.AddHeader("Accept", "application/json, text/plain, */*");

        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }

        if (body != null)
        {
            foreach (var param in body)
            {
                restRequest.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
            }
        }

        restResponse = restClient.ExecutePostAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;
        return restResponse;
    }

    public RestResponse DelRequest(string endP, Dictionary<string, string>? body = null,
        Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Delete);

        restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
        restRequest.AddHeader("Accept", "application/json, text/plain, */*");
        restRequest.AddHeader("X-LANGUAGE-LOCALE", "tr");


        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }

        if (body != null)
        {
            foreach (var param in body)
            {
                restRequest.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
            }
        }

        restResponse = restClient.ExecuteAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;
        return restResponse;
    }

    public RestResponse DelRequest(string endP, Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Delete);

        restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
        restRequest.AddHeader("Accept", "application/json, text/plain, */*");

        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }

        restResponse = restClient.ExecuteAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;
        return restResponse;
    }

    public RestResponse PutRequest(string endP, Dictionary<string, string>? body = null,
        Dictionary<string, string>? headers = null)
    {
        restClient = new RestClient(baseUrl ?? throw new InvalidOperationException());
        restRequest = new RestRequest(endP, Method.Put);

        restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded;charset=UTF-8");
        restRequest.AddHeader("Accept", "application/json, text/plain, */*");

        if (headers != null)
        {
            foreach (var header in headers)
            {
                restRequest.AddHeader(header.Key, header.Value);
            }
        }

        if (body != null)
        {
            foreach (var param in body)
            {
                restRequest.AddParameter(param.Key, param.Value, ParameterType.GetOrPost);
            }
        }

        restResponse = restClient.ExecutePutAsync(restRequest).GetAwaiter().GetResult();
        responseString = restResponse.Content;
        return restResponse;
    }


    /// <summary>
    /// Json Path Should Return Only A Value
    /// If return value is array or list, dont use this method.
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public string? SearchWithJsonPath(string path)
    {
        var jsonObj = JObject.Parse(responseString ?? throw new ArgumentNullException(nameof(responseString)));

        var pathResult = jsonObj.SelectToken(path);

        return pathResult?.ToString();
    }

    public string? SearchArrayWithJsonPath(string path)
    {
        JArray jsonArray = JArray.Parse(responseString ?? throw new ArgumentNullException(nameof(responseString)));

        var jsonObjects = (JObject) jsonArray[0];

        var pathResult = jsonObjects.SelectToken(path);

        return pathResult?.ToString();
    }
}

public static class User
{
    public static string? Username { get; set; }
    public static string? UserId { get; set; }
    public static string? UserAuthToken { get; set; }
    public static string? UserCsrfToken { get; set; }
}