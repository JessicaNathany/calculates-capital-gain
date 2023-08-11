using Newtonsoft.Json;

namespace CalculatesCapitalGain.Dtos
{
    public class FeeDto
    {
        [JsonProperty("tax")]
        public decimal Tax { get; set; }

        public FeeDto()
        {
            Tax = 0;
        }

        public FeeDto(decimal tax)
        {
            Tax = tax;
        }
    }
}
