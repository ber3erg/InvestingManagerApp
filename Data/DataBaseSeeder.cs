using InvestingManagerApp.Services;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.Data
{
    public static class DataBaseSeeder
    {
        public static void Seed(AppDbContext context)
        {
            context.Database.Migrate();

            SeedSecurities(context);
            SeedAdmin(context);
        }

        public static void SeedAdmin(AppDBContext dbContext)
        {
            if (!dbContext.Persons.Any(p => p.IsAdmin == true))
            {
                var newAdmin = new Person("Мисье Админ", "Admin", "123", true);
                dbContext.Persons.Add(newAdmin);
                dbContext.SaveChanges();
            }
        }

        public static void SeedSecurities(AppDBContext context) 
        { 
            if (context.Securities.Any())
            {
                return;
            }

            
            var securities = new List<Security>
            {
                new Security { Name = "Сбербанк", Ticker = "SBER", Company = "ПАО Сбербанк", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Сбербанк-п", Ticker = "SBERP", Company = "ПАО Сбербанк", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Газпром", Ticker = "GAZP", Company = "ПАО Газпром", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "ЛУКОЙЛ", Ticker = "LKOH", Company = "ПАО ЛУКОЙЛ", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Магнит", Ticker = "MGNT", Company = "ПАО Магнит", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "НОВАТЭК", Ticker = "NVTK", Company = "ПАО НОВАТЭК", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Норникель", Ticker = "GMKN", Company = "ПАО ГМК Норильский никель", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Роснефть", Ticker = "ROSN", Company = "ПАО НК Роснефть", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Аэрофлот", Ticker = "AFLT", Company = "ПАО Аэрофлот", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Мосбиржа", Ticker = "MOEX", Company = "ПАО Московская биржа", CurrentPrice = 0m, Type = SecurityType.Stock },

                new Security { Name = "МТС", Ticker = "MTSS", Company = "ПАО МТС", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "АЛРОСА", Ticker = "ALRS", Company = "АК АЛРОСА ПАО", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Северсталь", Ticker = "CHMF", Company = "ПАО Северсталь", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "ФСК-Россети", Ticker = "FEES", Company = "ПАО ФСК-Россети", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "РусГидро", Ticker = "HYDR", Company = "ПАО РусГидро", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Интер РАО", Ticker = "IRAO", Company = "ПАО Интер РАО", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Сургутнефтегаз", Ticker = "SNGS", Company = "ПАО Сургутнефтегаз", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Сургутнефтегаз-п", Ticker = "SNGSP", Company = "ПАО Сургутнефтегаз", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "Татнефть", Ticker = "TATN", Company = "ПАО Татнефть", CurrentPrice = 0m, Type = SecurityType.Stock },
                new Security { Name = "ВТБ", Ticker = "VTBR", Company = "Банк ВТБ ПАО", CurrentPrice = 0m, Type = SecurityType.Stock },

                new Security { Name = "ОФЗ 26212", Ticker = "SU26212RMFS9", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26218", Ticker = "SU26218RMFS6", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26228", Ticker = "SU26228RMFS5", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26230", Ticker = "SU26230RMFS1", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26232", Ticker = "SU26232RMFS7", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26233", Ticker = "SU26233RMFS5", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26235", Ticker = "SU26235RMFS0", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26236", Ticker = "SU26236RMFS8", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26237", Ticker = "SU26237RMFS6", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26238", Ticker = "SU26238RMFS4", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },

                new Security { Name = "ОФЗ 26239", Ticker = "SU26239RMFS2", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26240", Ticker = "SU26240RMFS0", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26241", Ticker = "SU26241RMFS8", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26242", Ticker = "SU26242RMFS6", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26243", Ticker = "SU26243RMFS4", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26244", Ticker = "SU26244RMFS2", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26245", Ticker = "SU26245RMFS9", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26246", Ticker = "SU26246RMFS7", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26247", Ticker = "SU26247RMFS5", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },
                new Security { Name = "ОФЗ 26248", Ticker = "SU26248RMFS3", Company = "Министерство финансов Российской Федерации", CurrentPrice = 0m, Type = SecurityType.Bond },

                new Security { Name = "БПИФ Первая Топ Рос. акций", Ticker = "SBMX", Company = "УК Первая", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ ТИНЬКОФФ ИНДЕКС МОСБИРЖИ", Ticker = "TMOS", Company = "УК Тинькофф", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Индекс МосБиржи", Ticker = "EQMX", Company = "УК ВИМ Инвестиции", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Ингосстрах Россия", Ticker = "INRU", Company = "УК Ингосстрах", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ ДОХОДЪ Инд дивид акций РФ", Ticker = "DIVD", Company = "УК ДоходЪ", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ МКБ Российские Див. Акции", Ticker = "MKBD", Company = "УК МКБ", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ РСХБ-МосБиржа-РСПП Вектор", Ticker = "ESGR", Company = "УК РСХБ", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Первая Ответствен инвест", Ticker = "SBRI", Company = "УК Первая", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Устойчивое Развитие Российских Компаний", Ticker = "ESGE", Company = "УК ВИМ Инвестиции", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Технологии будущего", Ticker = "SCFT", Company = "УК Система Капитал", CurrentPrice = 0m, Type = SecurityType.Fund },

                new Security { Name = "БПИФ Первая Халяльные инвестиции", Ticker = "SBHI", Company = "УК Первая", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Альфа Управляем Рос Акции", Ticker = "AKME", Company = "УК Альфа-Капитал", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ АТОН – Российские акции +", Ticker = "AMRE", Company = "УК АТОН", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ ДОХОДЪ Инд акций роста РФ", Ticker = "GROD", Company = "УК ДоходЪ", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Первая Акции средней и малой капитализации", Ticker = "SBSC", Company = "УК Первая", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Ликвидность", Ticker = "LQDT", Company = "АО ВИМ Инвестиции", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Альфа-Капитал Денежный рынок", Ticker = "AKMM", Company = "УК Альфа-Капитал", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Первая – Фонд Сберегательный", Ticker = "SBMM", Company = "УК Первая", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ БКС Денежный рынок", Ticker = "BCSD", Company = "УК БКС", CurrentPrice = 0m, Type = SecurityType.Fund },
                new Security { Name = "БПИФ Атон – Накопительный в рублях", Ticker = "AMNR", Company = "УК АТОН", CurrentPrice = 0m, Type = SecurityType.Fund },
            };
            
            context.Securities.AddRange(securities);
            context.SaveChanges();

        }

    }
}
