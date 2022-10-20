﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DurationCalculator
{
    public class FileController
    {
        private string path;

        public string OutputText { get; set; }
        public List<GradeDurationModel> GradeDurations { get; set; }


        public FileController(string path)
        {
            this.path = Directory.GetCurrentDirectory() + $"\\{path}";
            GradeDurations = new List<GradeDurationModel>();
        }

        /// <summary>
        /// Get total times based on what level/grade is in the file
        /// </summary>
        /// <returns>List of strings</returns>
        public List<string> GetGradeTotalTimes()
        {
            GetText();
            List<string> totalTimesToString = new List<string>();
            int GradeDurationsLength=GradeDurations.Count;
            int levelsLength = GradeDurations[0]._levels.Count;
            int[][] times = new int[levelsLength][];

            for(int i=0; i<GradeDurationsLength; i++)
            {
                for(int j=0; j<levelsLength; j++)
                {
                    if (GradeDurations[i]._levels[j] == true)
                    {
                        times[j]=StringDateConvertor.TimeSum(times[j], GradeDurations[i]._duration);
                    }
                }
            }
            
            foreach(var time in times)
            {
                var normalized=StringDateConvertor.TimeArrayNormalize(time);
                totalTimesToString.Add($"{normalized[0]}h {normalized[1]}m");
            }
            return totalTimesToString;

        }

        /// <summary>
        /// Read text from file
        /// </summary>
        private void GetText()
        {
            Console.WriteLine(path);
            if( File.Exists(path))
            {
                OutputText=File.ReadAllText(path);
            }
            GetRows();

        }

        /// <summary>
        /// Convert String into GradeDurationModel List
        /// </summary>
        private void GetRows()
        {
            List<string[]> Rows = new List<string[]>();
            var rows = OutputText.Split("\n");
            foreach (var row in rows)
            {
                Rows.Add(row.Split("\t"));
            }
            foreach (var row in Rows)
            {
                var duration = new GradeDurationModel();
                duration._duration = StringDateConvertor.ConvertStringToIntArray(row[0]);
                for (int i = 1; i < row.Length; i++)
                {
                    
                    if(row[i].Contains("✅")){
                        duration._levels.Add(true);
                    }
                    else
                    {
                        duration._levels.Add(false);
                    }

                }
                GradeDurations.Add(duration);
            }
        }

    }
}