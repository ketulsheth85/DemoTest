using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using SongsApp.Controllers;
using SongsApp.Models;
using SongsApp.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SongAppUnitTest
{
    [TestClass]
    public class AppUnitTest 
    {
         private HttpClient client;
        
        [TestMethod]
        public void GetSongsTest()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://www.songsterr.com");

            SongsApiService songsApiService = new SongsApiService(client);
            Task<List<SongsModel>> songsModels;
            songsModels = songsApiService.GetSongs(50, "Marely");
        }
    }
}
