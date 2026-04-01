using InvestingManagerApp.Data;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public class PersonService
    {
        public void RemovePerson(int personId)
        {
            var db = new AppDBContext();
            var portfolios = db.Portfolios.Where(p => p.PersonId == personId).ToList();
            foreach (var portfolio in portfolios)
            {
                var transactions = db.Transactions.Where(t => t.PortfolioId == portfolio.Id).ToList();
                foreach (var transaction in transactions) 
                {
                    db.Transactions.Remove(transaction);
                }
                db.Portfolios.Remove(portfolio);
            }
            var person = db.Persons.First(p => p.Id == personId);
            db.Persons.Remove(person);
            db.SaveChanges();
        }

        public List<Person> GetPeople()
        {
            var db = new AppDBContext();
            var people = db.Persons.ToList();
            return people;
        }
    }
}
