using System.Collections.Concurrent;
using System.Linq;

namespace ASCO.Models
{
    public class AdminSingleton
    {
        private static AdminSingleton _instance;
        private static readonly object _lock = new object();
        private DBACSOEntities db = new DBACSOEntities(); // Replace with your actual DbContext

        // Track active sessions by admin ID
        private static ConcurrentDictionary<int, string> activeSessions = new ConcurrentDictionary<int, string>();

        private AdminSingleton() { }

        public static AdminSingleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new AdminSingleton();
                    }
                    return _instance;
                }
            }
        }

        // Method to validate admin credentials using the database context
        public Admin ValidateAdmin(string admin_name, string admin_pass)
        {
            return db.Admins.FirstOrDefault(a => a.admin_name == admin_name && a.admin_pass == admin_pass);
        }

        // Method to check if an admin is already logged in
        public bool IsAdminLoggedIn(int adminId)
        {
            return activeSessions.ContainsKey(adminId);
        }

        // Method to register a session for an admin
        public void RegisterSession(int adminId, string sessionId)
        {
            activeSessions.AddOrUpdate(adminId, sessionId, (key, oldValue) => sessionId);
        }

        // Method to unregister a session for an admin
        public void UnregisterSession(int adminId)
        {
            activeSessions.TryRemove(adminId, out _);
        }
    }
}
