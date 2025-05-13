using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace InvestingManagerApp.Services
{
    public static class JsonFilePaths
    {
        private static readonly string ProjectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));

        public static readonly string admin = Path.Combine(ProjectRoot, "Data", "admin.json");
        public static readonly string users = Path.Combine(ProjectRoot, "Data", "users.json");
        public static readonly string portfolios = Path.Combine(ProjectRoot, "Data", "portfolios.json");
        public static readonly string securities = Path.Combine(ProjectRoot, "Data", "securities.json");
        public static readonly string transactions = Path.Combine(ProjectRoot, "Data", "transactions.json");

    }
}
