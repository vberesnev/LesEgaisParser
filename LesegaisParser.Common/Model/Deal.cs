using System;
using Newtonsoft.Json;

namespace LesegaisParser.Common.Model
{
    public class Deal
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty("sellerName")]
        public string SellerName { get; set; }

        [JsonProperty("sellerInn")]
        public string SellerInn { get; set; }
        
        [JsonProperty("buyerName")]
        public string BuyerName { get; set; }

        [JsonProperty("buyerInn")]
        public string BuyerInn { get; set; }

        [JsonProperty("woodVolumeBuyer")]
        public double WoodVolumeBuyer { get; set; }

        [JsonProperty("woodVolumeSeller")]
        public double WoodVolumeSeller { get; set; }

        [JsonProperty("dealDate")]
        public DateTime DealDate { get; set; }

        [JsonProperty("dealNumber")]
        public string DealNumber { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Deal deal)
            {
                return SellerName.Equals(deal.SellerName)
                       && SellerInn.Equals(deal.SellerInn)
                       && BuyerName.Equals(deal.BuyerName)
                       && WoodVolumeBuyer.Equals(deal.WoodVolumeBuyer)
                       && WoodVolumeSeller.Equals(deal.WoodVolumeSeller)
                       && DealNumber.Equals(deal.DealNumber);
            }

            return false;
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(SellerName);
            hashCode.Add(SellerInn);
            hashCode.Add(BuyerName);
            hashCode.Add(BuyerInn);
            hashCode.Add(WoodVolumeBuyer);
            hashCode.Add(WoodVolumeSeller);
            hashCode.Add(DealDate);
            hashCode.Add(DealNumber);
            hashCode.Add(Typename);
            return hashCode.ToHashCode();
        }
    }

    public class ContentWrapper
    {
        [JsonProperty("content")]
        public Deal[] Deals { get; set; }
    }

    public class Data
    {
        [JsonProperty("searchReportWoodDeal")]
        public ContentWrapper Content { get; set; }
    }

    public class ResponseWrapper
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}