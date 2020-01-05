using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace totleAPI.totleDecode
{
    public class swapReturnDecode
    {
        public swapReturnObj decode(string data)
        {
            try
            {
                return JsonConvert.DeserializeObject<swapReturnObj>(data);
            }
            catch (Exception i)
            {

                return null;
            }
        }
    }

    public class swapReturnObj
    {
        public swapRetResponse response;
        public bool success;
    }

    public class swapRetResponse
    {
        public string id;
        public swapReturnSummary[] summary;
        public swapTransactions[] transactions;
        public totleExpiration expiration;
    }

    public class partnerFee
    {
        public partnerFeeAsset asset;
        public string percentage;
        public string amount;
    }

    public class partnerFeeAsset
    {
        public string address;
        public string symbol;
        public string decimals;
    }

    public class swapReturnSummary
    {
        public string rate;
        public totleDestinationAsset destinationAsset;
        public string destinationAmount;
        public swapReturnTrades[] trades;
        public string sourceAmount;
        public totleFee totleFee;
        public totleSourceAsset sourceAsset;
        public totleMarket market;
        public string guaranteedRate;
        public partnerFee partnerFee;


    }

    public class swapTransactions
    {
        public string type;
        public totleTx tx;
    }

    public class totleTx
    {
        public string to;
        public string from;
        public string value;
        public string data;
        public string gasPrice;
        public string gas;
        public string nonce;
    }

    public class totleExpiration
    {
        public string blockNumber;
        public string estimatedTimestamp;
    }

    public class totleDestinationAsset
    {
        public string address;
        public string symbol;
        public string decimals;
    }

    public class totleSourceAsset
    {
        public string address;
        public string symbol;
        public string decimals;
    }

    public class totleExchange
    {
        public int id;
        public string name;
    }

    public class totleFee
    {
        public string percentage;
        public string amount;

    }

    public class totleAsset
    {
        public string address;
        public string amount;
        public totleAsset asset;
    }

    public class totleOrders
    {
        public totleSourceAsset sourceAsset;
        public totleDestinationAsset destinationAsset;
        public string sourceAmount;
        public string destinationAmount;
        public totleExchange exchange;
        public totleFee fee;
    }

    public class totleMarket
    {
        public string rate;
        public string slippage;
    }

    public class swapReturnTrades
    {
        public totleSourceAsset sourceAsset;
        public totleDestinationAsset destinationAsset;
        public string sourceAmount;
        public string destinationAmount;
        public totleOrders[] orders;

    }
}
