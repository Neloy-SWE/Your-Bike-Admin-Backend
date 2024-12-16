using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace your_bike_admin_backend.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public bool Read { get; set; }
        public required string Brand { get; set; }
        public required string Model { get; set; }

    }
}
