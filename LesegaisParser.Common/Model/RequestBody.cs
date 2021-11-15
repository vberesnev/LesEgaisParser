using System.ComponentModel;
using LesegaisParser.Common.Extensions;
using Newtonsoft.Json;

namespace LesegaisParser.Common.Model
{
    public class RequestBody
    {
        [JsonProperty("query")]
        public string Query { get; }

        [JsonProperty("variables")]
        public Variables Variables { get; }
        
        [JsonProperty("operationName")]
        public string OperationName { get; }

        private RequestBody()
        {
            Query = RequestConstants.Query;
            OperationName = RequestConstants.OperationName;
        }
        
        public RequestBody(int size, int number) : this()
        {
            Variables = new Variables(size, number);
        }

        public RequestBody(int size, int number, SortProperty property, SortDirection direction) : this()
        {
            Variables = new Variables(size, number, property, direction);
        }
    }

    public class Variables
    {
        [JsonProperty("size")]
        public int Size { get; }

        [JsonProperty("number")]
        public int Number { get; }

        [JsonProperty("filter")]
        public object Filter { get; }

        [JsonProperty("orders")]
        public Order[] Orders { get;  }

        public Variables(int size, int number)
        {
            Size = size;
            Number = number;
            Filter = null;
            Orders = null;
        }

        public Variables(int size, int number, SortProperty property, SortDirection direction)
        {
            Size = size;
            Number = number;
            Filter = null;
            Orders = new Order[1]
            {
                new Order(property, direction)
            };
        }
    }

    public class Order
    {
        [JsonProperty("property")]
        public string Property { get; }

        [JsonProperty("direction")]
        public string Direction { get; }

        public Order(SortProperty property, SortDirection direction)
        {
            Property = property.GetEnumDescription();
            Direction = direction.GetEnumDescription();
        }
    }

    public static class RequestConstants
    {
        public static string Query =
            "query SearchReportWoodDeal($size: Int!, $number: Int!, $filter: Filter, $orders: [Order!]) {\n  searchReportWoodDeal(filter: $filter, pageable: {number: $number, size: $size}, orders: $orders) {\n    content {\n      sellerName\n      sellerInn\n      buyerName\n      buyerInn\n      woodVolumeBuyer\n      woodVolumeSeller\n      dealDate\n      dealNumber\n      __typename\n    }\n    __typename\n  }\n}\n";

        public static string OperationName = "SearchReportWoodDeal";
    }

    public enum SortProperty
    {
        [Description("dealDate")]
        DealDate,
    }

    public enum SortDirection
    {
        [Description("ASC")]
        Ask,
        [Description("DESC")]
        Desk
    }
}