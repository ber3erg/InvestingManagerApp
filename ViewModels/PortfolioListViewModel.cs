using InvestingManagerApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InvestingManagerApp.ViewModels
{
    public class PortfolioListViewModel
    {
        public ObservableCollection<Portfolio> Portfolios { get; set; }

        public PortfolioListViewModel()
        {
            Portfolios = new ObservableCollection<Portfolio>
            {
                new Portfolio("Tech"),
                new Portfolio("Learning")
            };
        }
    }
}