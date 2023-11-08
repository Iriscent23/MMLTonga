using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MMLTonga.Models
{
    public class ExchangeRate
    {
        [Key]
        public string Country { get; set; }
        public string Currency { get; set; }

        [DisplayName("Send Rate")]
        public string SendRate { get; set; }

        [DisplayName("Receive Rate")]
        public string ReceiveRate { get; set; }
    }
}
