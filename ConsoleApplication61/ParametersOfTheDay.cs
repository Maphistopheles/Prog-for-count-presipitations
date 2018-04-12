using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication61
{
    class ParametersOfTheDay
    {

        public DateTime Date { get; set; }
        public double Temperature { get; set; }
        public double Precip { get; set; }
        public double Snow { get; set; }
        public double EfectPrecip { get; set; }
        public double WaterPenitr { get; set; }
        public double IncrPart { get; set; }
        public double Trend { get; set; }

        public ParametersOfTheDay()
        {
            Temperature = 0;
            Precip = 0;
            Snow = 0;
            EfectPrecip = 0;
            WaterPenitr = 0;
            IncrPart = 0;
            Trend = 0;
            
        }

        public override string ToString()
        {
            return string.Format("{0:d}	{1:f5}	{2:f5}	{3:f5}	{4:f5}	{5:f5} {6:f5}", Date,
                Temperature,
                Precip,
                Snow,
                EfectPrecip,
                WaterPenitr,
                IncrPart);
        }

        
    }
}
