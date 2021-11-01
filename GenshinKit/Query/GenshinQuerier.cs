using System;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using AHpx.Extensions.StringExtensions;
using Flurl.Http;
using GenshinKit.Data;
using GenshinKit.Data.Exceptions;
using GenshinKit.Data.Query;
using GenshinKit.Utility;
using Newtonsoft.Json;

namespace GenshinKit.Query
{
    public class GenshinQuerier
    {
        public GenshinQueryConfig Config { get; set; }

        public async Task<GenshinIndex> GetIndexAsync()
        {
            var server = Config.Uid.DistinguishGenshinServer();
            var ds = AlgorithmHelper.GetDs(Config.Uid);
            var random = new Random();
            
            //need a appropriate algorithm to balance load
            var cookie = Config.Cookies.ToList()[random.Next(Config.Cookies.Count())];

            var response = await $"{server.GetGenshinApiEndpoint()}index?server={server}&role_id={Config.Uid}"
                .WithHeader("x-rpc-client_type", "5")
                .WithHeader("DS", ds)
                .WithHeader("x-rpc-app_version", Config.Version)
                .WithHeader("Cookie", cookie)
                .GetStringAsync();

            if (response.Fetch("retcode") != "0")
            {
                throw new GenshinQueryException(
                    response.Fetch($"Failed to query: {response.Fetch("message")}"));
            }

            return JsonConvert.DeserializeObject<GenshinIndex>(response.Fetch("data"));
        }
    }
}