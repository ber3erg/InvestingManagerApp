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
            if (!File.Exists(filename))
            {
                return new List<T>(); // Возвращаем пустой список, если файл не найден
            }

            try
            {
                string objectsJson = File.ReadAllText(filename, Encoding.UTF8);
                if (string.IsNullOrWhiteSpace(objectsJson))
                {
                    return new List<T>(); // Возвращаем пустой список, если файл пуст
                }

                // Десериализация JSON в список
                List<T> resultList = JsonSerializer.Deserialize<List<T>>(objectsJson);
                return resultList ?? new List<T>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                return new List<T>(); // Возвращаем пустой список в случае ошибки
            }

        }

        public static void WriteItemsToJsonFile<T>(List<T> items, string filePath)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
            };

            string jsonString = JsonSerializer.Serialize(items, options);
            var utf8WithBom = new UTF8Encoding(encoderShouldEmitUTF8Identifier: true);
            File.WriteAllText(filePath, jsonString, utf8WithBom);
        }

        public static List<Admin> GetAdminsFromJsonFile()
        {
            List<Admin> adminsFromJson = GetAllFromFile<Admin>(JsonFilePaths.admin);
            return adminsFromJson;
        }
        public static List<User> GetUsersFromJsonFile()
        {
            List<User> usersFromJson = GetAllFromFile<User>(JsonFilePaths.users);
            if (usersFromJson.Count > 0)
            {
                int maxId = usersFromJson.Max(s => s.Id);
                User.SetCounter(maxId);
            }
            return new List<User>(usersFromJson);
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
            try
            {
                // Записываем в файл, используя правильную кодировку
                File.WriteAllText(filePath, jsonString, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в файл: {ex.Message}");
            }
        }
        public static void AddAdminToJsonFile(Admin _admin)
        {
            AddItemToJsonFile<Admin>(_admin, JsonFilePaths.admin);
        }

        public static void AddUserToJsonFile(User _user)
        {
            List<User> users = GetUsersFromJsonFile();
            users.Add(_user);
            WriteItemsToJsonFile<User>(users, JsonFilePaths.users);
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
            for (int i = 0; i < items.Count; i++)
            {
                //if (items[i].Id == securityId)
                //{
                //    var security = Securities[i];
                //    Securities.RemoveAt(i);
                //    JsonDataStorage.DeleteSecurityFromJsonFile(security);
                //    break; // Выход, если Id уникальный
                //}
            }

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

        public static void DeleteAdminFromJsonFile(Admin _admin)
        {
            DeleteItemFromJsonFile<Admin>(_admin, JsonFilePaths.admin);
        }

        public static void DeletePortfolioFromJsonFile(Portfolio _portfolio)
        {
            DeleteItemFromJsonFile<Portfolio>(_portfolio, JsonFilePaths.portfolios);
        } 
        

        public static void DeleteTransactionFromJsonFile(Transaction _transaction)
        {
            DeleteItemFromJsonFile<Transaction>(_transaction, JsonFilePaths.transactions);
        } 
    }
}
