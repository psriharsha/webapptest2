using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PhoneBookTestApp
{
    public class Person
    {
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name \t\t" + Name + "\n");
            sb.Append("PhoneNumber \t" + PhoneNumber + "\n");
            sb.Append("Address \t" + Address + "\n");
            return sb.ToString();
        }
    }
}