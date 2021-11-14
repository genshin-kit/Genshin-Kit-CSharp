using System;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using Flurl;
using Flurl.Http;
using GenshinKit.Data;
using GenshinKit.Data.Exceptions;
using GenshinKit.Data.Query;
using GenshinKit.Utility;   

namespace GenshinKit.Query
{
    internal class GenshinQuerier
    {
        public GenshinQuerier(GenshinQueryConfig config = null)
        {
            Config = config;
        }

        internal GenshinQueryConfig Config { get; set; }

        internal async Task<GenshinIndex> GetIndexAsync()
        {
            return await RequestHelper.GetAsync<GenshinIndex>(Config);
        }

        internal async Task<GenshinAbyss> GetAbyssAsync()
        {
            return await RequestHelper.GetAsync<GenshinAbyss>(Config);
        }
    }
}