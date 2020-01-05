using System.Collections.Generic;

namespace totleAPI.totlePOSTbodies
{
    //https://developers.totle.com/reference#swap
    public class swapBodyObjMultiple
    {
        public string address;
        public string apiKey;
        public swapBodyConfig config;
        public string partnerContract;
        public List<swapBodySwapObj> swaps = new List<swapBodySwapObj>();
    }
}