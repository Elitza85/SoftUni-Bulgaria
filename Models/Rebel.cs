using P06.BirthdayCelebrations;
using P06.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P05.BorderControl.Models
{
    public class Rebel : IGrowable, IBuyer
    {
        private readonly string group;

        private const int StartFood = 0;
        private const int IncreaseFoodBy = 5;

        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.group = group;
            this.Food = StartFood;
        }

        public string Name { get; private set; }

        public int Age { get; private set; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            this.Food += IncreaseFoodBy;
        }
    }
}
