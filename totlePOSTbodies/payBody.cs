namespace totleAPI.totlePOSTbodies
{
    public class payBody
    {
        public string address; //your wallet address
        public string apiKey;
        public swapBodyConfig config; //Transaction/trade-related information
        public string partnerContract; //the smart contract address if you're a totle partner
        public swapBodySwapObj swap; //Information about the single trading pair to be executed
    }
}