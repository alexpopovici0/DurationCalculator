using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DurationCalculator
{
    public static class StringDateCalculator
    {

        /// <summary>
        /// Convert string into array of int[3]
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int[] ConvertStringToIntArray(string time)
        {
            var durationTime = new int[] {0,0,0};
            string[] timeSplited = time.Split(" ");

            foreach(string s in timeSplited)
            {
                if (s.Contains("h"))
                {
                    durationTime[0]=Int32.Parse(s.Replace("h", ""));
                }
                if (s.Contains("m"))
                {
                    durationTime[1] = Int32.Parse(s.Replace("m", ""));
                }
                if (s.Contains("s"))
                {
                    durationTime[2] = Int32.Parse(s.Replace("s", ""));
                }
            }
            return durationTime;
        }

        /// <summary>
        /// Makes sum of 2 int[3]
        /// </summary>
        /// <param name="time1"></param>
        /// <param name="time2"></param>
        /// <returns></returns>
        public static int[] TimeSum(int[] time1, int[] time2)
        {
            if (time1 != null && time1.Length == time2.Length)
            {
                for (int i=0; i < time1.Length; i++)
                {
                    time1[i] = time1[i] + time2[i];
                }
            }
            else
            {
                return time2;
            }
            return time1;
        }

        /// <summary>
        /// Normalize int[3] having a time format h m s
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int[] TimeArrayNormalize(int[] time)
        {
            int[] temp = (int[])time.Clone();
            for (int i = 2; i >=1; i--)
            {
                while (temp[i] >= 60)
                {
                    temp[i-1]++;
                    temp[i] = temp[i] - 60;
                }
            }
            return temp;
        }

        public static int[] TimeWithOverhead(int[] time)
        {
            int[] temp = (int[])time.Clone();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = temp[i] + temp[i] / 2;
            }
            return TimeArrayNormalize(temp);
        }

        public static int[] AverageTimeDay(int[] time)
        {
            int[] temp = (int[])time.Clone();
            temp = ChangeHoursToMinutes(temp, 45);
            return TimeArrayNormalize(temp);
        }

        public static int[] AverageTimeWeek(int[] time)
        {
            int[] temp = (int[])time.Clone();
            temp = ChangeHoursToMinutes(temp, 9);
            return TimeArrayNormalize(temp);
        }

        private static int [] ChangeHoursToMinutes(int[] time,int division)
        {
            int[] temp = (int[])time.Clone();
            temp[1] = temp[0] * 60;
            temp[2] = temp[1] * 60;
            temp[2] = temp[2] / division;
            temp[0] = 0;
            temp[1] = 0;
            return temp;
        }


    }
}
