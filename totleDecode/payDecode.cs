using System;
using Newtonsoft.Json;

namespace totleAPI.totleDecode
{
    public class payDecode
    {
        public static TotlePayObj decode(string dat)
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<TotlePayObj>(dat);
                return obj;
            }
            catch (Exception i)
            {
                return null;
            }
        }
    }

    public class TotlePayObj
    {
        public TotleTokensObj[] tokens;
    }

    public class TotleTokensObj
    {
        public string address;
        public int decimals;
        public string name;
        public string symbol;
        public bool tradeable;
    }
}