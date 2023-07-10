namespace DotNetCoreRazor.Extensions
{
    public static class SessionExtensions
    {
        public static Dictionary<string, object?> ToDictionary(this ISession session){
            var values = new Dictionary<string, object?>();
            foreach(var sessionKey in session.Keys)
            {
                values.Add(sessionKey, session.GetString(sessionKey));
            }
            return values;
        }
    }
}
