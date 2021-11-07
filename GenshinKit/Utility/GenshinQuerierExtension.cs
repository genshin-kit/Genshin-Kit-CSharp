using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AHpx.Extensions.StringExtensions;
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
        /// <param name="ds"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithGenshinDs(this GenshinQueryConfig config, string ds)
        {
            config.Ds = ds;
            
            return config;
        }

        /// <summary>
        /// Use your custom dynamic secret
        /// </summary>
        /// <param name="config"></param>
        /// <param name="dsProvider"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithGenshinDs(this GenshinQueryConfig config, Func<string> dsProvider)
        {
            config.Ds = dsProvider();

            return config;
        }

        /// <summary>
        /// Use your specified hoyolab version
        /// </summary>
        /// <param name="config"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithHoyolabVersion(this GenshinQueryConfig config, string version)
        {
            config.Version = version;

            return config;
        }

        /// <summary>
        /// Use your specified hoyolab version
        /// </summary>
        /// <param name="config"></param>
        /// <param name="versionProvider"></param>
        /// <returns></returns>
        public static GenshinQueryConfig WithHoyolabVersion(this GenshinQueryConfig config, Func<string> versionProvider)
        {
            config.Version = versionProvider();

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
            config.Language = language;
            
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
            //specify default configurations
            config.Ds ??= config.Uid.GetGenshinServerType() == GenshinServerType.Oversea
                ? AlgorithmHelper.GetDs()
                : AlgorithmHelper.GetDs(config.Uid);

            config.Version ??= "2.11.1";
            config.Language ??= GenshinLanguage.en_us;
                
            if (config.Uid.IsNullOrEmpty())
                throw new GenshinQueryException("Invalid config specified!");

            if (!config.Cookies.Any())
                throw new GenshinQueryException("Invalid cookie specified!");
            
            return await new GenshinQuerier { Config = config }.GetIndexAsync();
        }
    }
}