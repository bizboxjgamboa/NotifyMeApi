namespace NotifyMeApi.Models
{
	public class NotificationRequest
	{
        public string Text { get; set; }
        public string Action { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
        public bool Silent { get; set; }
    }
}
