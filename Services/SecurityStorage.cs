using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public static class SecurityStorage
    {
        public static List<Security> Securities { get; private set; } = JsonDataStorage.GetSecuritiesFromJsonFile();

        public static void AddSecurity(Security security)
        {
            Securities.Add(security);
            JsonDataStorage.AddSecurityToJsonFile(security);
        }

        public static void RemoveSecurity(int securityId)
        {   
            foreach (Security security in Securities) 
            {
                if (security.Id == securityId)
                {
                    Securities.Remove(security);
                    JsonDataStorage.DeleteSecurityFromJsonFile(security);
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
            return new List<Security>(Securities); // Возвращаем копию
        }
    }
}

