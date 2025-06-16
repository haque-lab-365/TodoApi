using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiscExperiment
{
    public class RecordExperiment
    {

        public readonly record struct DailyTemperature1(double HighTemp, double LowTemp);
        public readonly record struct DailyTemperature0(double HighTemp, double LowTemp)
        { 
            public double Mean => (HighTemp + LowTemp) / 2.0;
        }


        /// <summary>
        /// To compute degree days, you take the difference from a baseline temperature and the mean temperature on a given day. 
        /// To measure heat over time, you discard any days where the mean temperature is below the baseline. 
        /// </summary>
        /// <param name="BaseTemperature"></param>
        /// <param name="TempRecords"></param>
        public abstract record DegreeDays(double BaseTemperature, IEnumerable<DailyTemperature0> TempRecords);

        public sealed record HeatingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature0> TempRecords) : 
            DegreeDays(BaseTemperature, TempRecords)
        {
            public double DegreeDays => TempRecords.Where(s => s.Mean < BaseTemperature).Sum(s => BaseTemperature - s.Mean);
        }

        public sealed record CoolingDegreeDays(double BaseTemperature, IEnumerable<DailyTemperature0> TempRecords) :
            DegreeDays(BaseTemperature, TempRecords)
        {
            public double DegreeDays => TempRecords.Where(s => s.Mean > BaseTemperature).Sum(s => s.Mean - BaseTemperature);
        }

        RecordExperiment() { }

        //--Let's populate some data
        private static DailyTemperature0[] recordData = [
            new DailyTemperature0(HighTemp: 57, LowTemp: 30.0),
            new DailyTemperature0(60, 35),
            new DailyTemperature0(63, 36),
            new DailyTemperature0(68, 38),
            new DailyTemperature0(72, 31),
            new DailyTemperature0(75, 33),
            new DailyTemperature0(77, 29),
            new DailyTemperature0(70, 47),
            new DailyTemperature0(77, 55),
            new DailyTemperature0(85, 55),
            new DailyTemperature0(87, 58),
            new DailyTemperature0(85, 47),
            new DailyTemperature0(87, 59),
            new DailyTemperature0(85, 65),
            new DailyTemperature0(83, 65),
            new DailyTemperature0(77, 58),
            new DailyTemperature0(72, 55),
            new DailyTemperature0(77, 53),
            new DailyTemperature0(76, 60),
            new DailyTemperature0(76, 66),
        ];

       
        public static void showRecordData()
        {
            foreach (var item in recordData)
            {
                Console.WriteLine($"High: {item.HighTemp}, Low: {item.LowTemp}, Mean: {item.Mean}");
            }

            var heatingDegreeDays = new HeatingDegreeDays(65, recordData);
            //--Console.WriteLine($"Heating Degree Days: {heatingDegreeDays.DegreeDays}");
            Console.WriteLine($"Heating Degree Days: {heatingDegreeDays}");

            var coolingDegreeDays = new CoolingDegreeDays(65, recordData);
            //--Console.WriteLine($"Cooling Degree Days: {coolingDegreeDays.DegreeDays}");
            Console.WriteLine($"Cooling Degree Days: {coolingDegreeDays}");
        }

    }

    //--https://learn.microsoft.com/en-us/dotnet/csharp/tutorials/records
}
