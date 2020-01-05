using Newtonsoft.Json;

namespace totleAPI.totleDecode
{
    public class exchangesDecode
    {
        public static TotleExchangeObj decode(string data)
        {
            var ret = JsonConvert.DeserializeObject<TotleExchangeObj>(data);
            return ret;
        }
    }

    public class TotleExchangeObj
    {
        public TotleExch[] exchanges;
    }

    public class TotleExch
    {
        public bool enabled;
        public string iconurl;
        public int id;
        public string name;
    }
}