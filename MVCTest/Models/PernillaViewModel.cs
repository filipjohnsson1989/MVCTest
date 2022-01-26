using System.ComponentModel;

namespace MVCTest.Models
{
    public class PernillaViewModel
    {
        public int Id { get; set; }

        [DisplayName ("First Name")]
        public string FirstName { get; set; }
    }
}
