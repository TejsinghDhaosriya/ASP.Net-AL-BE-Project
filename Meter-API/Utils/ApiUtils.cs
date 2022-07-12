namespace Meter_API.Utils
{
    public static class ApiUtils
    {
        public static bool IsEmpty(string req)
        {
            var isNullOrEmpty = string.IsNullOrEmpty(req);
            return isNullOrEmpty;
        }
    }
}
