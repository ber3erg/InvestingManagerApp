using InvestingManagerApp.Data;
using InvestingManagerApp.Models;

namespace InvestingManagerApp.Services
{
    public class PersonService
    {
        public void RemovePerson(int personId)
        {
            using var db = new AppDBContext();
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
        public Person GetPersonById(int personId)
        {
            using var db = new AppDBContext();
            var finded = db.Persons.First(p => p.Id == personId);
            return finded;
        }

        public List<Person> GetPeople()
        {
            using var db = new AppDBContext();
            var people = db.Persons.Where(p => p.IsAdmin == false).ToList();
            return people;
        }

        public void EditPerson(Person newPerson)
        {
            using var db = new AppDBContext();
            var oldPerson = db.Persons.First(p => p.Id == newPerson.Id);

            oldPerson.Login = newPerson.Login;
            oldPerson.Password = newPerson.Password;
            oldPerson.Name = newPerson.Name;

            db.SaveChanges();
        }
    }
}
