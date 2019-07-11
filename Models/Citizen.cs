using P06.BirthdayCelebrations.Interfaces;
using System;

namespace P06.BirthdayCelebrations
{
    public class Citizen : IIdentifiable,
        IBirthable, IGrowable, IBuyer
    {
        private const int StartFood= 0;
        private const int IncreaseFoodBy = 10;

        public Citizen(string name,int age, string id, string date)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
            this.Food = StartFood;
        }
        public string Id { get; private set; }

        public string Name { get; private set; }

        public DateTime BirthDate { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += IncreaseFoodBy;
        }
    }
}
