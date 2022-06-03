using System.ComponentModel.DataAnnotations.Schema;

namespace TradingAppData.Datamodel
{
    public class Customer
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TradingName { get; set; }
        public string Password { get; set; }
        public string TradingToken { get; set; }
    }
}
