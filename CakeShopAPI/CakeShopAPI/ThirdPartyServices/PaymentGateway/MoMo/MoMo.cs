using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CakeShopAPI.ThirdPartyServices.PaymentGateway.MoMo
{
    public class MoMo
    {
        private string accessKey;
        private string secretKey;
        private string apiEndpoint;
        private string redirectUrl;
        private string ipnUrl;
        private string partnerCode;

        private string amount;
        private string orderInfo;
        private string signature;
        private string partnerName = "Tiệm Bánh 101";
        private string storeId = "101CakeShop";
        private string requestId = Guid.NewGuid().ToString();
        private string orderId;
        private string requestType = "captureWallet";
        private string extraData = "";
        private string lang = "vi";

        public MoMo(string amount, string orderInfo, string orderId)
        {
            this.amount = amount;
            this.orderInfo = orderInfo;
            this.orderId = orderId;

            var buider = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = buider.Build();

            accessKey = config["MoMo:accessKey"];
            secretKey = config["MoMo:secretKey"];
            apiEndpoint = config["MoMo:apiEndpoint"];
            redirectUrl = config["MoMo:redirect"];
            ipnUrl = config["MoMo:ipn"];
            partnerCode = config["MoMo:partnerCode"];

            string rawHash =
                "accessKey=" + accessKey +
                "&amount=" + this.amount +
                "&extraData=" + extraData +
                "&ipnUrl=" + ipnUrl +
                "&orderId=" + orderId +
                "&orderInfo=" + this.orderInfo +
                "&partnerCode=" + partnerCode +
                "&redirectUrl=" + redirectUrl +
                "&requestId=" + requestId +
                "&requestType=" + requestType;

            signature = Security.signSHA256(rawHash, secretKey);
        }

        public string GetResponseFromMoMo()
        {
            JObject messageRequest = new JObject
            {
                { "partnerCode", partnerCode },
                { "partnerName", partnerName },
                { "storeId", storeId },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderId },
                { "orderInfo", orderInfo },
                { "redirectUrl", redirectUrl },
                { "ipnUrl", ipnUrl },
                { "lang", lang },
                { "extraData", extraData },
                { "requestType", requestType },
                { "signature", signature }
            };

            string messageResponse = PaymentRequest.SendPaymentRequest(apiEndpoint, messageRequest.ToString());

            return messageResponse;
        }
    }
}
