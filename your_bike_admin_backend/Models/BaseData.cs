namespace your_bike_admin_backend.Models
{
    public class BaseData<T>
    {
        public required string Status { get; set; }
        public required string Message { get; set; }
        public required T Data { get; set; }
    }
}
