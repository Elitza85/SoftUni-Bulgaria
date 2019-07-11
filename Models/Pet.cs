using System;

namespace P06.BirthdayCelebrations
{
    public class Pet : ICallableByName, IBirthable
    {
        public Pet(string name, string date)
        {
            this.Name = name;
            this.BirthDate = DateTime.ParseExact(date, "dd/MM/yyyy", null);
        }

        public string Name { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
