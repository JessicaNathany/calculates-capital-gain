using Newtonsoft.Json;

namespace CalculatesCapitalGain.Dtos
{
    public class TaxDto
    {
        [JsonProperty("tax")]
        public decimal Tax { get; set; }

        public TaxDto()
        {
            Tax = 0;
        }

        public TaxDto(decimal tax)
        {
            Tax = tax;
        }
    }
}
