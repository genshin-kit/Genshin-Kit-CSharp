using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
using Flurl;
using GenshinKit.Data;
using GenshinKit.Data.Exceptions;
using GenshinKit.Data.Query;
using GenshinKit.Data.Request;
using GenshinKit.Query;

namespace GenshinKit.Utility
{
    public static class GenshinQuerierExtension
    {
        /// <summary>
        /// Add a genshin cookie
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithGenshinCookie(this string uid, GenshinCookie cookie)
        {
            return new GenshinQueryConfig
            {
                Cookies = new[] { cookie },
                Uid = uid,
            };
        }

        /// <summary>
        /// Add some genshin cookies
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithGenshinCookies(this string uid, IEnumerable<GenshinCookie> cookies)
        {
            return new GenshinQueryConfig
            {
                Cookies = cookies,
                Uid = uid,
            };
        }
        
        /// <summary>
        /// Add a genshin cookie
        /// </summary>
        /// <param name="config"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithGenshinCookie(this GenshinQueryConfig config, GenshinCookie cookie)
        {
            config.Cookies = new List<GenshinCookie>(config.Cookies)
            {
                cookie
            };

            return config;
        }

        /// <summary>
        /// Add some genshin cookies
        /// </summary>
        /// <param name="config"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithGenshinCookies(this GenshinQueryConfig config, IEnumerable<GenshinCookie> cookies)
        {
            var appendCookies = new List<GenshinCookie>(config.Cookies);
            appendCookies.AddRange(cookies);

            config.Cookies = appendCookies;

            return config;
        }

        /// <summary>
        /// Use your custom dynamic secret
        /// </summary>
        /// <param name="config"></param>
        /// <param name="dynamic"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithGenshinDynamic(this GenshinQueryConfig config, GenshinDynamic dynamic)
        {
            if (config.Uid.IsOversea())
                config.Dynamic[1] = dynamic;
            else
                config.Dynamic[0] = dynamic;

            return config;
        }

        /// <summary>
        /// With user specified language
        /// </summary>
        /// <param name="config"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithLanguage(this GenshinQueryConfig config, GenshinLanguage language)
        {
            config.Language = language.ToString().Replace("_", "-");
            
            return config;
        }

        /// <summary>
        /// You don't have to invoke this in the chain, but you can as you want lol
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <exception cref="GenshinQueryException"></exception>
        public static GenshinQueryConfig WithDefaultConfig(this GenshinQueryConfig config)
        {
            //specify default configurations
            
            if (config.Uid.IsOversea())
            {
                config.Dynamic[1].Ds ??= config.GetDs();
                config.Dynamic[1].Version ??= "1.5.0";
            }
            else
            {
                config.Dynamic[0].Ds ??= config.GetDs();
                config.Dynamic[0].Version ??= "2.11.1";
            }

            config.Language ??= GenshinLanguage.en_us.ToString().Replace("_", "-");
                
            //throw exceptions if any
            if (config.Uid.IsNullOrEmpty())
                throw new GenshinQueryException("Invalid config specified!");

            if (!config.Cookies.Any())
                throw new GenshinQueryException("Invalid cookie specified!");

            return config;
        }
        
        /// <summary>
        /// Query for general info of specified config
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        /// <exception cref="GenshinQueryException"></exception>
        public static async Task<GenshinIndex> GetGenshinIndexAsync(this GenshinQueryConfig config)
        {
            var server = config.Uid.GetGenshinServer();

            config.Url = $"{server.GetGenshinApiEndpoint(GenshinEndpoint.index)}?server={server}&role_id={config.Uid}";
            
            config = config.WithDefaultConfig();
            
            return await new GenshinQuerier(config).GetIndexAsync();
        }

        /// <summary>
        /// Query for chronicle of spiral abyss 
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static async Task<GenshinAbyss> GetGenshinAbyssAsync(this GenshinQueryConfig config, bool previous = false)
        {
            var server = config.Uid.GetGenshinServer();
            var extra = previous ? new { schedule_type = 2 } : new { schedule_type = 1 };

            config.Url = $"{server.GetGenshinApiEndpoint(GenshinEndpoint.spiralAbyss)}?server={server}&role_id={config.Uid}"
                .SetQueryParams(extra);
            
            config = config.WithDefaultConfig();

            return await new GenshinQuerier(config).GetAbyssAsync();
        }
    }
}