using Newtonsoft.Json;

namespace CalculatesCapitalGain.Dtos
{
    public class OrderDto
    {
        /// <summary>
        /// If the transaction is a buy transaction ( buy ) or sell ( sell )
        /// </summary>
        [JsonProperty("operation")]
        public string Operation { get; set; }

        /// <summary>
        /// Unity price of the share in one currency to two decimal places
        /// </summary>
        [JsonProperty("unit-cost")]
        public decimal UnitCoast { get; set; }

        /// <summary>
        /// Unit price of the share in one currency to two decimal places
        /// </summary>
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
