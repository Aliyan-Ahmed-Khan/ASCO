namespace ASCO.Models
{
    public class LoggingObserver : IObserver
    {
        public void Update(string message)
        {
            // Log the message (you can integrate with any logging framework here)
            System.Diagnostics.Debug.WriteLine($"Logging: {message}");
        }
    }
}