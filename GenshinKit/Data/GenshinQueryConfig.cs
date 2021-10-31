namespace GenshinKit.Data
{
    public class GenshinQueryConfig
    {
        internal string Ds { get; set; }

        /// <summary>
        /// Version of hoyolab
        /// </summary>
        public string Version { get; set; }

        public string Cookie { get; set; }

        internal string Url { get; set; }

        public string Uid { get; set; }

        internal GenshinServer Server { get; set; }
    }
}