using System.Collections.Generic;
using System.Net.Http;
using ApiTesting.Models;
using Reqnroll;

namespace ApiTesting.Context;

[Binding]
public class ResponseContext
{
    public HttpResponseMessage responseMessage { get; set; }
    public List<GetObjectResponse> responseBody { get; set; }
    
}