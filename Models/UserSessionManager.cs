using System.Collections.Concurrent;
using System.Collections.Generic;

namespace ASCO.Models
{
    public class UserSessionManager : ISubject
    {
        private static UserSessionManager _instance;
        private static readonly object _lock = new object();
        private List<IObserver> _observers = new List<IObserver>();
        private ConcurrentDictionary<int, string> activeUserSessions = new ConcurrentDictionary<int, string>();

        private UserSessionManager() { }

        public static UserSessionManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserSessionManager();
                    }
                    return _instance;
                }
            }
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        public void RegisterUserSession(int userId, string sessionId)
        {
            activeUserSessions.AddOrUpdate(userId, sessionId, (key, oldValue) => sessionId);
            Notify($"User logged in: ID {userId}");
        }

        public void UnregisterUserSession(int userId)
        {
            activeUserSessions.TryRemove(userId, out _);
            Notify($"User logged out: ID {userId}");
        }

        public IEnumerable<string> GetActiveSessions()
        {
            var activeSessions = new List<string>();

            foreach (var session in activeUserSessions)
            {
                activeSessions.Add($"User ID: {session.Key}, Session ID: {session.Value}");
            }

            return activeSessions;
        }
    }
}