using Newtonsoft.Json;

namespace totleAPI.totleDecode
{
    public class tokensDecode
    {
        public static TotleTokenObj decode(string data)
        {
            var ret = JsonConvert.DeserializeObject<TotleTokenObj>(data);
            return ret;
        }
    }

    public class TotleTokenObj
    {
        public TotleTokens[] tokens;
    }

    public class TotleTokens
    {
        public string address;
        public int decimals;
        public string name;
        public string symbol;
        public bool tradable;
    }
}