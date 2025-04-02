namespace BlazorApp1.Models
{
    public class ServersRepository
    {
        private static List<Server> servers = CreateNewServerList(25) ?? new List<Server>();

        private static List<Server>? CreateNewServerList(int serverCount)
        {
            var servers = new List<Server>();
            Random randomNumber = new Random();
            int isOnlineNumber, cityNumber;
            List<string> cities = CitiesRepository.GetCities();

            if (cities != null)
            {
                for (int i = 1; i <= serverCount; i++)
                {
                    isOnlineNumber = randomNumber.Next(0, 2);
                    cityNumber = randomNumber.Next(0, cities.Count);

                    servers.Add(new Server() { ServerId = i, Name = $"Server{i}", City = cities[cityNumber], IsOnline = isOnlineNumber == 0 ? false : true });
                }
                return servers;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Generate a new ID for a new server
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static int NewID()
        {
            if (servers == null || servers.Count == 0)
            {
                throw new InvalidOperationException("Cannot generate a new ID. The server list is null or empty.");
            }

            return servers.Max(s => s.ServerId) + 1;
        }

        public static void AddServer(Server server)
        {
            var maxId = servers.Max(s => s.ServerId);
            server.ServerId = maxId + 1;
            servers.Add(server);
        }

        public static List<Server> GetServers()
        {
            return servers;
        }

        public static List<Server> GetServersByCity(string cityName)
        {
            return servers.Where(s => s.City.Equals(cityName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static Server? GetServerById(int id)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == id);
            if (server != null)
            {
                return new Server
                {
                    ServerId = server.ServerId,
                    Name = server.Name,
                    City = server.City,
                    IsOnline = server.IsOnline
                };
            }
            return null;
        }

        public static void UpdateServer(int serverId, Server server)
        {
            if (serverId != server.ServerId) return;

            var serverToUpdate = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (serverToUpdate != null)
            {
                serverToUpdate.IsOnline = server.IsOnline;
                serverToUpdate.Name = server.Name;
                serverToUpdate.City = server.City;
            }
        }

        public static void DeleteServer(int serverId)
        {
            var server = servers.FirstOrDefault(s => s.ServerId == serverId);
            if (server != null)
            {
                servers.Remove(server);
            }
        }

        public static List<Server> SearchServers(string serverFilter)
        {
            return servers.Where(s => s.Name.Contains(serverFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}
