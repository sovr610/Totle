using System;
using Newtonsoft.Json;

namespace totleAPI.totleDecode
{
    public class swapDecode
    {
        public static TotleSwapObj decode(string data)
        {
            try
            {
                var dat = JsonConvert.DeserializeObject<TotleSwapObj>(data);
                return dat;
            }
            catch (Exception i)
            {
                return null;
            }
        }
    }

    public class TotleSwapObj
    {
        public TotleSwapErrResponse response;
        public bool success;
    }

    public class TotleSwapErrResponse
    {
        public int code;
        public string expiration;
        public string id;
        public string info;
        public string link;
        public string message;
        public string name;
        public string summary;
        public string transactions;
    }
}