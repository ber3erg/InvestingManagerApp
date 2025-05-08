using InvestingManagerApp.Models;
using System.IO;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using System.Text;


namespace InvestingManagerApp.Services
{
    public static class JsonDataStorage
    {      
        // =========== получение объектов ============
        // Для получения объектов реализованы следующие общие методы
        private static List<T> GetAllFromFile<T>(string filename){
            // для начала прочитаем содержимое файла
            // А также проведём десериализацию данных
            // Прочитанные данные помещаем в список
            string objectsJson = File.ReadAllText(filename, Encoding.UTF8);
            List<T> _objects = new List<T>();
            if (!string.IsNullOrWhiteSpace(objectsJson)){
                _objects = JsonSerializer.Deserialize<List<T>>(objectsJson)!;
            }
            return _objects;
        }

        public static List<Admin> GetAdminsFromJsonFile()
        {
            List<Admin> adminsFromJson = GetAllFromFile<Admin>(JsonFilePaths.admin);
            return adminsFromJson;
        }
        public static List<User> GetUsersFromJsonFile()
        {
            List<User> usersFromJson = GetAllFromFile<User>(JsonFilePaths.users);
            return usersFromJson;
        }

        public static List<Portfolio> GetPortfoliosFromJsonFile()
        {
            List<Portfolio> portfoliosFromJson = GetAllFromFile<Portfolio>(JsonFilePaths.portfolios);
            return portfoliosFromJson;
        }
        public static List<Security> GetSecuritiesFromJsonFile()
        {
            List<Security> SecuritiesFromJson = GetAllFromFile<Security>(JsonFilePaths.securities);
            return SecuritiesFromJson;
        }
        public static List<Transaction> GetTransactionsFromJsonFile()
        {
            List<Transaction> transactionsFromJson = GetAllFromFile<Transaction>(JsonFilePaths.transactions);
            return transactionsFromJson;
        }


        // =============== Добавление объектов в файлы ================
        // добавление объектов происходит по принципу: 
        // получение данных - добавление в список - сериализация и запись в файл

        public static void AddItemToJsonFile<T>(T item, string filePath)
        {
            List<T> items = GetAllFromFile<T>(filePath);
            items.Add(item);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string jsonString = JsonSerializer.Serialize(items, options);
            var utf8WithBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
            File.WriteAllText(filePath, jsonString, utf8WithBom);
        }
        public static void AddAdminToJsonFile(Admin _admin)
        {
            AddItemToJsonFile<Admin>(_admin, JsonFilePaths.admin);
        }

        public static void AddUserToJsonFile(User _user)
        {
            AddItemToJsonFile<User>(_user, JsonFilePaths.users);
        }

        public static void AddPortfolioToJsonFile(Portfolio _portfolio)
        {
            AddItemToJsonFile<Portfolio>(_portfolio, JsonFilePaths.portfolios);
        } 
        public static void AddSecurityToJsonFile(Security _security)
        {
            AddItemToJsonFile<Security>(_security, JsonFilePaths.securities);
        } 

        public static void AddTransactionToJsonFile(Transaction _transaction)
        {
            AddItemToJsonFile<Transaction>(_transaction, JsonFilePaths.transactions);
        } 

        // ================ Удаление объектов ==================
        
        // Удаление объекта происходит так
        // Получаем полностью список объектов из файла
        // удаляем объект и записываем список в файл
        public static void DeleteItemFromJsonFile<T>(T item, string filePath)
        {
            List<T> items = GetAllFromFile<T>(filePath);
            items.Remove(item);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string jsonString = JsonSerializer.Serialize(items, options);
            var utf8WithBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
            File.WriteAllText(filePath, jsonString, utf8WithBom);
        }

        public static void DeleteUserFromJsonFile(User _user)
        {
            DeleteItemFromJsonFile<Person>(_user, JsonFilePaths.users);
        }

        public static void DeleteUserFromJsonFile(Admin _admin)
        {
            DeleteItemFromJsonFile<Admin>(_admin, JsonFilePaths.admin);
        }

        public static void DeletePortfolioFromJsonFile(Portfolio _portfolio)
        {
            DeleteItemFromJsonFile<Portfolio>(_portfolio, JsonFilePaths.portfolios);
        } 
        public static void DeleteSecurityFromJsonFile(Security _security)
        {
            DeleteItemFromJsonFile<Security>(_security, JsonFilePaths.securities);
        } 

        public static void DeleteTransactionFromJsonFile(Transaction _transaction)
        {
            DeleteItemFromJsonFile<Transaction>(_transaction, JsonFilePaths.transactions);
        } 
    }
}
