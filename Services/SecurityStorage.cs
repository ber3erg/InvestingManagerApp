using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public static class SecurityStorage
    {
        public static List<Security> Securities { get; private set; }

        public static void AddSecurity(Security security)
        {
            Securities.Add(security);
            JsonDataStorage.AddSecurityToJsonFile(security);
        }

        public static void RemoveSecurityFromJson(int securityId)
        {
            for (int i = 0; i < Securities.Count; i++)
            {
                if (Securities[i].Id == securityId)
                {
                    Securities.RemoveAt(i);
                    JsonDataStorage.WriteItemsToJsonFile<Security>(Securities, JsonFilePaths.securities);
                    break; // Выход, если Id уникальный
                }
            }
        }

        public static void ChangeSecurityPrice(int securityId, decimal newPrice)
        {
            for (int i = 0; i < Securities.Count; i++)
            {
                if (Securities[i].Id == securityId)
                {
                    Securities[i].ChangeCurrentPrice(newPrice);
                    JsonDataStorage.WriteItemsToJsonFile<Security>(Securities, JsonFilePaths.securities);
                    break;
                }
            }
        }

        public static Security? GetSecurityById(int id)
        {
            foreach (Security security in Securities)
            {
                if (security.Id == id)
                {
                    return security;
                }
            }
            return null;
        }

        public static List<Security> GetAllSecurities()
        {
            Securities = JsonDataStorage.GetSecuritiesFromJsonFile();
            if (Securities.Count > 0)
            {
                int maxId = Securities.Max(s => s.Id);
                Security.SetCounter(maxId);
            }
            return new List<Security>(Securities);
        }
    }
}

