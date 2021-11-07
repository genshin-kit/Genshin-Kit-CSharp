namespace GenshinKit.Data.Request
{
    public class GenshinCookie
    {
        public string Cookie { get; set; }

        public GenshinServerType ServerType { get; set; }

        public GenshinCookie(string cookie = null, GenshinServerType serverType = default)
        {
            Cookie = cookie;
            ServerType = serverType;
        }

        public static implicit operator GenshinCookie(string s)
        {
            return new GenshinCookie
            {
                Cookie = s,
                ServerType = GenshinServerType.Chinese
            };
        } 
        
        public static implicit operator string(GenshinCookie s)
        {
            return s.Cookie;
        } 
    }
}