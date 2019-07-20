using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P01.Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] fields)
        {
            Type classType = typeof(Hacker);
            FieldInfo[] classFields= classType.GetFields(BindingFlags.Instance |
                BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            var sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f=>fields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
