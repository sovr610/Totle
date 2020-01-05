namespace totleAPI.totlePOSTbodies
{
    //https://developers.totle.com/reference#swap
    public class swapBodyObjSingle
    {
        public string address; //your wallet address
        public string apiKey;
        public swapBodyConfig config; //Transaction/trade-related information
        public string partnerContract; //the smart contract address if you're a totle partner
        public swapBodySwapObj swap; //Information about the single trading pair to be executed
    }

    public class swapBodyConfig
    {
        //public swapBodyConfigExchanges exchanges; //info about the exchanges to be used (or not used)

        public bool
            fillNonce; //Whether the nonce field in the response is populated or not (allows for manual population of nonce in cases where there are multiple transactions present).

        public bool
            skipBalanceChecks; //whether the API should validate the source asset balance of the wallet given in the address field.

        public bool
            transactions; //whether a response is returned or not (allows the submission of a request for accurate pricing info even if theres no intention to execute any trades).
    }

    public class swapBodyConfigExchanges
    {
        public int[] list; //IDs of the exchanges to whitelist/blacklist. use /exchanges for ID's
        public string type; //whether the exchange should be whitelisted or blacklisted (white or black)
    }

    public class swapBodySwapObj
    {
        public string destinationAddress; //
        //public double destinationAmount; //The amount of tokens to buy in the tokens base unit of decimals
        public string destinationAsset; //identifier of the token to buy
        public bool isOptional; //whether this trading pair can be skipped or not

        /*public string
            maxExecutionSlippagePercent; //Percentage of maxium acceptable slippage of market rate from the time the API finds the rate and executing swap on-chain. Value must be between 1-99, inclusive.

        public string
            maxMarketSlippagePercent; //Percentage of maximum acceptable market price slippage that can occur based off of 0.1 unit of source token while finding best rates off-chain. Value must be between 1-99, inclusive.

        public int
            minFillPercent; //percentage of minimum accept destination amount to receive. Value must be between 1-100, inclusive.
            */
        public double sourceAmount; //The amount of tokens to sell in the tokens base unit of decimals
        public string sourceAsset; //identifier of the token to sell
    }
}