using System.Collections.Generic;

namespace RealTime.Helpers {
    public static class HubHelper {
        private static HashSet<string> ConnectedIds = new HashSet<string>();

        public static void AddConn(string id) {
            ConnectedIds.Add(id);
        }
        public static void RemoveConn(string id) {
            ConnectedIds.Remove(id);
        }
        public static int GetCount() {
            return ConnectedIds.Count;
        }
    }
}