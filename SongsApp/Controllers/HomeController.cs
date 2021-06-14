using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SongsApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SongsApp.Services;

namespace SongsApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISongsApiService _songsApiService;

        public HomeController(ISongsApiService songsApiService)
        {
            _songsApiService = songsApiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> SearchSong(int size, string pattern)
        {
            Response objResponse = new Response();
            objResponse.pattern = pattern;
            if (!string.IsNullOrEmpty(pattern) && size > 0)
            {
                objResponse.lstsong = await _songsApiService.GetSongs(size, pattern);
            }
            return Json(objResponse);
        }
    }
}
