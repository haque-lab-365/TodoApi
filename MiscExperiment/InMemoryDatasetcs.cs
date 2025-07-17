using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiscExperiment
{
    public static class InMemoryDatasetcs
    {
        public static void ShowCountryList()
        {
            Dictionary<string, string> countries = new Dictionary<string, string>
            {
                { "USA", "United States" },
                { "CAN", "Canada" },
                { "GBR", "United Kingdom" },
                { "FRA", "France" },
                { "DEU", "Germany" },
                { "JPN", "Japan" },
                { "CHN", "China" },
                { "IND", "India" },
                { "BRA", "Brazil" },
                { "AUS", "Australia" },
                { "RUS", "Russia" },
                { "ZAF", "South Africa" },
                { "EGY", "Egypt" },
                { "MEX", "Mexico" },
                { "ITA", "Italy" },
                { "ESP", "Spain" },
                { "KOR", "South Korea" },
                { "NLD", "Netherlands" },
                { "SAU", "Saudi Arabia" },
                { "TUR", "Turkey" }
                // You can continue adding all other countries similarly
            };

            // 🔁 Step 2: Iterate and Display
            foreach (KeyValuePair<string, string> kvp in countries)
            {
                Console.WriteLine($"Code: {kvp.Key} - Country: {kvp.Value}");
            }
        }
    }
}
