using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SongsApp.Models;
namespace SongsApp.Services
{
    public interface ISongsApiService
    {
        Task<List<SongsModel>> GetSongs(int size, string pattern);
    }
}
