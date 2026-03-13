namespace InvestingManagerApp.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public int PersonId { get; set; }

        public string Name { get; set; }

        public Portfolio()
        {
        }
        public Portfolio(string name, int personId)
        {
            Name = name;
            PersonId = personId;
        }

        public void ChangeName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Name = name;
        }
    }
}
