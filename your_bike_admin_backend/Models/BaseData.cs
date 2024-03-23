namespace your_bike_admin_backend.Models
{
    public class BaseData<T>
    {
        public string status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
