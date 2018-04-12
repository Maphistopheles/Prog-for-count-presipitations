using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication61
{
    class ParamOfTheDayManager
    {
        private List<ParametersOfTheDay> _entries;
        private string _filePath;
        private double _snow;
        public double _incrPart;


        public ParamOfTheDayManager()
        {
            _entries = new List<ParametersOfTheDay>();
            _filePath = "";
        }

        public ParamOfTheDayManager(string filePath)
        {
            _entries = new List<ParametersOfTheDay>();
            ReadFromFile(filePath);
            
        }

        public void ReadFromFile(string filePath)
        {
            _filePath = filePath;
            StreamReader sr = File.OpenText(_filePath);
            while(!sr.EndOfStream)
            {
                this.AddEntryFromFileLine(sr.ReadLine());
            }
        }

        public void AddEntry(ParametersOfTheDay Day)
        {
            _entries.Add(Day);
        }

        public void AddEntryFromFileLine(string line)
        {
            string[] fields = line.Split('	');
            
            try
            {
                ParametersOfTheDay POTD = new ParametersOfTheDay();
                POTD.Date = Convert.ToDateTime(fields[0]);
                Console.WriteLine("Converting was Ok");
                Console.WriteLine(POTD.Date);
                Console.ReadKey();
                
                POTD.Temperature = Double.Parse(fields[1]);
                Console.WriteLine("Converting was Ok");
                Console.WriteLine(POTD.Temperature);
                Console.ReadKey();
                POTD.Precip = Double.Parse(fields[2]);
                Console.WriteLine("Converting was Ok");
                Console.WriteLine(POTD.Precip);
                Console.ReadKey();


                double K = POTD.Temperature * 5;
                if(POTD.Temperature <= 0)
                {
                    _snow += POTD.Precip;
                    POTD.Snow = _snow;
                }
                else if( POTD.Temperature > 0)
                {
                    if(_snow < K)
                    {
                        POTD.EfectPrecip = POTD.Precip + _snow;
                        _snow = 0;
                    }
                    else if(_snow > K)
                    {
                        _snow -= K;
                        POTD.EfectPrecip = POTD.Precip + K;
                    }
                }
                POTD.Snow = _snow;
                Console.WriteLine(POTD.Snow);

                POTD.WaterPenitr = WP(POTD);
                Console.WriteLine(POTD.WaterPenitr);

                POTD.IncrPart = _incrPart + POTD.WaterPenitr;
                _incrPart += POTD.WaterPenitr;
                Console.ReadKey();
                AddEntry(POTD);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public double WP(ParametersOfTheDay POTD)
        {
            double WaterPenitrate = 0;
            double Ewaporate = 0.283 * POTD.Temperature - 1.648;
            string S = string.Format("{0:MM}", POTD.Date);
            if(S != "12" || S != "01" || S != "02")
            {
                WaterPenitrate = POTD.EfectPrecip - WaterPenitrate;
            }
            else if(S == "12" || S == "01" || S == "02")
            {
                WaterPenitrate = POTD.EfectPrecip;
            }
            
            return WaterPenitrate;
        }
        
        public void MakeOutFile(string filepath)
        {
            FileStream file = new FileStream(filepath, FileMode.Create);
            StreamWriter WriteData = new StreamWriter(file);
            foreach(ParametersOfTheDay el in _entries)
            {
                WriteData.WriteLine(el.ToString());
            }
            WriteData.Close();
        }
    }
}
