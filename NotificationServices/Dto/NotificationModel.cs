namespace NotificationServices.Dto
{
    public class NotificationModel
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public object Data { get; set; }
    }
}
