﻿using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using PS.Template.Domain.Interfaces.RequestApis;
using Newtonsoft.Json;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace PS.Template.Application.RequestAPis
{
    public class GenerateRequest : IGenerateRequest
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _contextAccessor;

        public GenerateRequest(IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _configuration = configuration;
            _contextAccessor = contextAccessor;
        }

        public string GetUri()
        {
            string uri = _configuration.GetSection("URL:URI_SUCURSAL").Value;
            
            return uri;
        }

        public IEnumerable<T> ConsultarApiRest<T>(string uri, RestRequest request)
        {
            IRestClient client;
            IRestResponse queryResult;
            IEnumerable<T> hash = null;
            var headers = new Dictionary<string, string>
            {
                { "Content-Type", "application/json" },
                { "Accept", "application/json" }
            };
            try
            {
                client = new RestClient(uri);
                client.AddDefaultHeader("Content-Type", "application/json");
                request.AddHeaders(headers);
                request.RequestFormat = DataFormat.Json;
                queryResult = client.Execute(request);
                
                if (queryResult.StatusCode == HttpStatusCode.OK)
                {
                    hash = JsonConvert.DeserializeObject<IList<T>>(queryResult.Content);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return hash;
        }

        public void LeerClaims()
        {
            IEnumerable<Claim> cp = _contextAccessor.HttpContext.User.Claims;
            var a = _contextAccessor.HttpContext.Request.Headers.GetCommaSeparatedValues("Authorization");
        }
    }
}