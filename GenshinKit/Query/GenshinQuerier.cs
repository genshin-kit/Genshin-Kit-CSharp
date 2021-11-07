using System;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.JsonExtensions;
using Flurl.Http;
using GenshinKit.Data;
using GenshinKit.Data.Exceptions;
using GenshinKit.Data.Query;
using GenshinKit.Utility;
using Newtonsoft.Json;

namespace GenshinKit.Query
{
    internal class GenshinQuerier
    {
        internal GenshinQueryConfig Config { get; set; }

        internal async Task<GenshinIndex> GetIndexAsync()
        {
            var server = Config.Uid.GetGenshinServer();
            var ds = Config.Ds;
            var cookie = GetCookie();
            var language = Config.Language.ToString()!.Replace("_", "-");

            var response = await $"{server.GetGenshinApiEndpoint()}index?server={server}&role_id={Config.Uid}"
                .WithHeader("x-rpc-client_type", "5")
                .WithHeader("x-rpc-app_version", Config.Version)
                .WithHeader("x-rpc-language", language)
                .WithHeader("Cookie", cookie)
                .WithHeader("DS", ds)
                .GetStringAsync();
            
            if (response.Fetch("retcode") != "0")
            {
                throw new GenshinQueryException(
                    $"Failed to query: {response.Fetch("message")}");
            }

            return JsonConvert.DeserializeObject<GenshinIndex>(response.Fetch("data"));
        }

        string GetCookie()
        {
            var random = new Random();

            var cookies = (Config.Uid.GetGenshinServerType() == GenshinServerType.Oversea
                ? Config.Cookies.Where(x => x.ServerType == GenshinServerType.Oversea)
                : Config.Cookies.Where(x => x.ServerType == GenshinServerType.Chinese)).ToList();

            return cookies[random.Next(cookies.Count)];
        }
    }
}