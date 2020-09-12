using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checker1
{

    public class bpmcheck
    {
        internal void bpmchecker(float bpm)
        {
            if (bpm < 70)
                Console.WriteLine("bpm is less");
            if (bpm > 150)
                Console.WriteLine("bpm is high");
            else
                Console.WriteLine("bpm is normal");

        }
    }
    public class spo2check
    {
        internal void spo2checker(float spo2)
        {
            if (spo2 < 90)
                Console.WriteLine("spo2 level is low");
            else
                Console.WriteLine("spo2 level is normal");

        }
    }
    public class respratecheck
    {
        internal void respratechecker(float respRate)
        {
            if (respRate < 30)
                Console.WriteLine("respiration rate is less");
            if (respRate > 95)
                Console.WriteLine("respiration rate is high");
            else
                Console.WriteLine("respiration rate is normal");
        }
    }
    public delegate void CheckVitals(float value);
    public class Checker
    {
        CheckVitals vitals;
        public Checker(CheckVitals vitals)
        {
            this.vitals = vitals;
        }
        public void CheckVital(float value)
        {
            this.vitals.Invoke(value);
        }
    }
    class Program
    {
        static bpmcheck checkBPM = new bpmcheck();
        static spo2check checkSpo2 = new spo2check();
        static respratecheck checkRespRate = new respratecheck();
        static void Main(string[] args)
        {
            Checker checkVitalBpm = new Checker(new CheckVitals(checkBPM.bpmchecker));
            checkVitalBpm.CheckVital(90);

            Checker checkVitalSpo2 = new Checker(new CheckVitals(checkSpo2.spo2checker));
            checkVitalSpo2.CheckVital(69);

            Checker checkVitalRespRate = new Checker(new CheckVitals(checkRespRate.respratechecker));
            checkVitalRespRate.CheckVital(52);
        }
    }



}
