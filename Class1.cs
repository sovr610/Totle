using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using totleAPI.totleDecode;
using totleAPI.totlePOSTbodies;
using System.Net;

namespace totleAPI
{
    public class totleCore
    {
        public enum httpTypes
        {
            POST = 0,
            GET = 1,
            PUT = 2,
            DELETE = 3
        }

        private const string urlBase = "https://api.totle.com";

        private string performTotleCall(string endpoint, List<Tuple<string, string>> queryStr,
            List<Tuple<string, string>> headers, httpTypes http_type, object body = null, bool isMultipleSwap = false)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);

                if (queryStr != null)
                {
                    endpoint = endpoint + "?";
                    foreach (var qStr in queryStr) endpoint = endpoint + qStr.Item1 + "=" + qStr.Item2 + "&";
                    var one = endpoint.Length - 1;
                    endpoint = endpoint.Substring(0, one);
                }

                if (headers != null)
                    foreach (var head in headers)
                        client.DefaultRequestHeaders.Add(head.Item1, head.Item2);

                HttpContent httpContent = null;
                if (body != null)
                {
                    var inf = JsonConvert.SerializeObject(body);
                    httpContent = new StringContent(inf);
                    httpContent.Headers.ContentType.MediaType = "application/json";
                }

                HttpResponseMessage msg = null;
                if (http_type == httpTypes.GET) msg = client.GetAsync(endpoint).Result;

                if (http_type == httpTypes.POST) msg = client.PostAsync(endpoint, httpContent).Result;

                if (http_type == httpTypes.DELETE) msg = client.DeleteAsync(endpoint).Result;

                if (http_type == httpTypes.PUT) msg = client.PutAsync(endpoint, httpContent).Result;
                if (msg.IsSuccessStatusCode)
                {
                    var ret = msg.Content.ReadAsStringAsync().Result;
                    return ret;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("issue with totle endpoint: " + endpoint);
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
            catch (Exception i)
            {
                return null;
            }
        }


        public TotleExchangeObj getExchanges()
        {
            try
            {
                var exchs = performTotleCall("/exchanges", null, null, httpTypes.GET);
                var exchDecode = exchangesDecode.decode(exchs);
                return exchDecode;
            }
            catch (Exception i)
            {
                return null;
            }
        }

        public TotleTokenObj getTokens()
        {
            try
            {
                var tokens = performTotleCall("/tokens", null, null, httpTypes.GET);
                var tokenDecode = tokensDecode.decode(tokens);
                return tokenDecode;
            }
            catch (Exception i)
            {
                return null;
            }
        }

        public swapReturnObj pushSwap(swapBodyObjMultiple body, string coin)
        {
            try
            {
                string f = body.swaps[0].destinationAsset;
                var swapRet = performTotleCall("/swap", null, null, httpTypes.POST, body);
                swapReturnDecode swap = new swapReturnDecode();
                var obj = swap.decode(swapRet);
                return obj;
            }
            catch (Exception i)
            {
                return null;
            }
        }

        public swapReturnObj pushSwap(swapBodyObjSingle body)
        {
            try
            {
                
                var swapRet = performTotleCall("/swap", null, null, httpTypes.POST, body);
                swapReturnDecode swap = new swapReturnDecode();
                var obj = swap.decode(swapRet);
                return obj;
            }
            catch (Exception i)
            {
                return null;
            }
        }

        public TotlePayObj pushPay(payBody body)
        {
            try
            {
                var payRet = performTotleCall("/pay", null, null, httpTypes.POST, body);
                var obj = payDecode.decode(payRet);
                return obj;
            }
            catch (Exception i)
            {
                return null;
            }
        }
    }
}