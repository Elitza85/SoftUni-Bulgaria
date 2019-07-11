using P05.BorderControl.Models;
using P06.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.BirthdayCelebrations
{
    public class Engine
    {
        private List<IBuyer> data;

        public Engine()
        {
            data = new List<IBuyer>();
        }

        public void Run()
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                if (input.Length == 3)
                {
                    string rebelName = input[0];
                    int rebelAge = int.Parse(input[1]);
                    string group = input[2];

                    var rebel = new Rebel(rebelName, rebelAge, group);

                    data.Add(rebel);
                }
                else if (input.Length == 4)
                {
                    string citizenName = input[0];
                    int citizenAge = int.Parse(input[1]);
                    string id = input[2];
                    string date = input[3];

                    var citizen = new Citizen(citizenName, citizenAge, id, date);

                    data.Add(citizen);
                }
            }

            string line = string.Empty;

            while ((line=Console.ReadLine())!="End")
            {
                var foundPerson = data.SingleOrDefault(p=>p.Name==line);

                if(foundPerson!= null)
                {
                    
                }
            }
        }

    }
}
