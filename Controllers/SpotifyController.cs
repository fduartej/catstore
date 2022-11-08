using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


using catstore.DTO.gorest;
using catstore.DTO.spotify;

namespace catstore.Controllers
{
    //https://learn.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
    public class SpotifyController : Controller
    {
        private readonly ILogger<SpotifyController> _logger;
        //private const string URL_BASE="https://api.spotify.com";
        private const string URL_BASE="https://gorest.co.in";
        //private const string URL_API="/v1/me";
        private const string URL_API="/public/v2/users";
        
        private const string ACCESS_TOKEN ="BQAEP7oDswW2t-Xu9Voyx33B6m9ApCqalgRz6Vu6sDJBOxpQETXZTZIKsN5rpcHPgn7DAP52IHMMCXElnDZxDP487JNRavb1mqoLDI5r7FyGMThLFmDJHGfIHww1xu1Yd5aYxDVVdQNEPdfI3yTduJcrsyN_uEOxlbSv77JsX10N-AlHoR27ttBPGdplvw1UCp7zVlk5g7BpRYyg";


        public SpotifyController(ILogger<SpotifyController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(string? strtoken)
        {
            var token = ACCESS_TOKEN;
            if(!String.IsNullOrEmpty(strtoken)){
                token = strtoken;
            }

            //GET https://gorest.co.in/public/v2/users HTTP/1.1
            //Accept: application/json
            
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.BaseAddress = new Uri(URL_BASE);
            
            // aqui agregar en caso necesita token
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            //codigo para en caso de enviar un post con un request
            //var users = new catstore.DTO.gorest.Users();
            //users.email ="";
            //HttpResponseMessage response = await httpClient.PostAsJsonAsync(URL_API,users);

            HttpResponseMessage response = await httpClient.GetAsync(URL_API);
            List<Users>? me = await response.Content.ReadFromJsonAsync<List<Users>>();
            

            //UserSpotify? me = await response.Content.ReadFromJsonAsync<UserSpotify>();
            return View("IndexGorest",me);
            //return View(me);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}