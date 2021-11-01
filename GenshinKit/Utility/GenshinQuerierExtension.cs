using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using GenshinKit.Data;
using GenshinKit.Data.Exceptions;
using GenshinKit.Data.Query;
using GenshinKit.Query;

namespace GenshinKit.Utility
{
    public static class GenshinQuerierExtension
    {
        public static GenshinQueryConfig WithGenshinCookie(this string uid, string cookie)
        {
            return new GenshinQueryConfig
            {
                Cookies = new[] { cookie },
                Uid = uid,
                Ds = AlgorithmHelper.GetDs(uid),
                Version = "2.11.1"
            };
        }

        public static GenshinQueryConfig WithGenshinCookies(this string uid, IEnumerable<string> cookies)
        {
            return new GenshinQueryConfig
            {
                Cookies = cookies,
                Uid = uid,
                Ds = AlgorithmHelper.GetDs(uid),
                Version = "2.11.1"
            };
        }

        public static GenshinQueryConfig WithGenshinDs(this GenshinQueryConfig config, string ds)
        {
            config.Ds = ds;
            
            return config;
        }

        public static GenshinQueryConfig WithGenshinDs(this GenshinQueryConfig config, Func<string> dsProvider)
        {
            config.Ds = dsProvider();

            return config;
        }

        public static GenshinQueryConfig WithHoyolabVersion(this GenshinQueryConfig config, string version)
        {
            config.Version = version;

            return config;
        }

        public static GenshinQueryConfig WithHoyolabVersion(this GenshinQueryConfig config, Func<string> versionProvider)
        {
            config.Version = versionProvider();

            return config;
        }
        
        public static async Task<GenshinIndex> GetGenshinIndexAsync(this GenshinQueryConfig config)
        {
            if (config.Uid.IsNullOrEmpty())
                throw new GenshinQueryException("Invalid uid specified!");

            if (!config.Cookies.Any())
                throw new GenshinQueryException("Invalid cookie specified!");
            
            return await new GenshinQuerier { Config = config }.GetIndexAsync();
        }
    }
}