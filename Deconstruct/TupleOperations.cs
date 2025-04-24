using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deconstruct
{
    public class TupleOperations
    {
        public static void TupleActgions()
        {
            //--However, there are cases in which an out parameter can be of a tuple type. The following example shows how to work with tuples as out parameters:
            var limitsLookup = new Dictionary<int, (int Min, int Max)>()
            {
                [2] = (4, 10),
                [4] = (10, 20),
                [6] = (0, 23)
            };

            if (limitsLookup.TryGetValue(4, out (int Min, int Max) limits))
            {
                Console.WriteLine($"Found limits: min is {limits.Min}, max is {limits.Max}");
            }
            // Output:
            // Found limits: min is 10, max is 20

            Dictionary<string, string> result = GetSampleDictionary();
            foreach (var item in result)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }
        static Dictionary<string, string> GetSampleDictionary()
        {
            Dictionary<string, string> data = new Dictionary<string, string>
            {
                { "Key1", "Value1" },
                { "Key2", "Value2" },
                { "Key3", "Value3" }
            };

            return data;
        }
        private static Dictionary<string, string> StateDataSource()
        {
            //--https://www.faa.gov/air_traffic/publications/atpubs/cnt_html/appendix_a.html
            Dictionary<string, string> statesTerritory = new Dictionary<string, string>();
            statesTerritory.Add("Alabama", "AL");
            statesTerritory.Add("Alaska", "AK");
            statesTerritory.Add("Arizona", "AZ");
            statesTerritory.Add("Arkansas", "AR");
            statesTerritory.Add("American Samoa", "AS");
            statesTerritory.Add("California", "CA");
            statesTerritory.Add("Colorado", "CO");
            statesTerritory.Add("Connecticut", "CT");
            statesTerritory.Add("Delaware", "DE");
            statesTerritory.Add("District of Columbia", "DC");
            statesTerritory.Add("Florida", "FL");
            statesTerritory.Add("Georgia", "GA");
            statesTerritory.Add("Guam", "GU");
            statesTerritory.Add("Hawaii", "HI");
            statesTerritory.Add("Idaho", "ID");
            statesTerritory.Add("Illinois", "IL");
            statesTerritory.Add("Indiana", "IN");
            statesTerritory.Add("Iowa", "IA");
            statesTerritory.Add("Kansas", "KS");
            statesTerritory.Add("Kentucky", "KY");
            statesTerritory.Add("Louisiana", "LA");
            statesTerritory.Add("Maine", "ME");
            statesTerritory.Add("Maryland", "MD");
            statesTerritory.Add("Massachusetts", "MA");
            statesTerritory.Add("Michigan", "MI");
            statesTerritory.Add("Minnesota", "MN");
            statesTerritory.Add("Mississippi", "MS");
            statesTerritory.Add("Missouri", "MO");
            statesTerritory.Add("Montana", "MT");
            statesTerritory.Add("Nebraska", "NE");
            statesTerritory.Add("Nevada", "NV");
            statesTerritory.Add("New Hampshire", "NH");
            statesTerritory.Add("New Jersey", "NJ");
            statesTerritory.Add("New Mexico", "NM");
            statesTerritory.Add("New York", "NY");
            statesTerritory.Add("North Carolina", "NC");
            statesTerritory.Add("North Dakota", "ND");
            statesTerritory.Add("orthern Mariana Islands", "MP");
            statesTerritory.Add("Ohio", "OH");
            statesTerritory.Add("Oklahoma", "OK");
            statesTerritory.Add("Oregon", "OR");
            statesTerritory.Add("Pennsylvania", "PA");
            statesTerritory.Add("Puerto Rico", "PR");
            statesTerritory.Add("Rhode Island", "RI");
            statesTerritory.Add("South Carolina", "SC");
            statesTerritory.Add("South Dakota", "SD");
            statesTerritory.Add("Tennessee", "TN");
            statesTerritory.Add("Texas", "TX");
            statesTerritory.Add("Trust Territories", "TT");
            statesTerritory.Add("Utah", "UT");
            statesTerritory.Add("Vermont", "VT");
            statesTerritory.Add("Virginia", "VA");
            statesTerritory.Add("Virgin Islands", "AK");
            statesTerritory.Add("Washington", "WA");
            statesTerritory.Add("West Virginia", "WV");
            statesTerritory.Add("Wisconsin", "WI");
            statesTerritory.Add("Wyoming", "WY");

            return statesTerritory;
        }
    }
}
