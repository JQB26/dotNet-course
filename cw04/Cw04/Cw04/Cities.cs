using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cw04
{
    class Cities
    {
        public Dictionary<string, List<string>> Data;

        public Cities()
        {
            GetData();
        }

        private void GetData()
        {
            var inputList = new List<string>();
            var city = Console.ReadLine();
            while (city != null && !city.Equals("X"))
            {
                inputList.Add(city);
                city = Console.ReadLine();
            }

            Data = inputList.GroupBy(o => o[..1])
                .ToDictionary(g => g.Key, g => g.OrderBy(s => s).ToList());
        }

        public void Start()
        {
            while (true)
            {
                CitiesRequest(Console.ReadLine());
            }
        }

        private void CitiesRequest(string letter)
        {
            if (Data.ContainsKey(letter))
            {
                foreach (var city in Data[letter])
                {
                    Console.Write($"{city}, ");
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("PUSTE");
            }
        }
    }
}
