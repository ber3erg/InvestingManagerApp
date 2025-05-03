using InvestingManagerApp.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InvestingManagerApp.ViewModels
{
    public class PortfolioDetailsViewModel
    {
        public ObservableCollection<Security> Securities { get; set; }

        public PortfolioDetailsViewModel(Portfolio portfolio)
        {
            Securities = new ObservableCollection<Security>(portfolio.Securities);
        }
    }
}