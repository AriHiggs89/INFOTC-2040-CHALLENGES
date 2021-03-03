using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace CrimeAnalyzer
{
    public class Crimes
    {
        private static List<CrimeData> CrimeDataList = new List<CrimeData>();
        
        public Crimes(string[] args)
        {
            string csv = string.Empty;
            string report = string.Empty;
            string firstPath = Directory.GetCurrentDirectory();

            //Debugging
            if (Debugger.IsAttached)
            {
                csv = Path.Combine(firstPath, "CrimeAnalyzer.csv");
                report = Path.Combine(firstPath, "CrimeReport.txt");
            }
            else
            {
                if (args.Length!=2)
                {
                    Console.WriteLine("Invalid command. \n This is a valid command: CrimeAnalyzer<crimeanalyzer><report>");
                    Console.ReadLine();
                    return;
                }
                else
                {
                    csv = args[0];
                    report = args[1];
                    if(!csv.Contains("\\"))
                    {
                        csv = Path.Combine(firstPath, csv);
                    }

                    if(!report.Contains("\\"))
                    {
                        report = Path.Combine(firstPath, report);
                    }
                }
            }
            
            if(File.Exists(csv))
            {
                if(ReadFile(csv))
                {
                    try
                    {
                        var file = File.Create(report);
                        file.Close();
                    }
                    catch(Exception)
                    {
                        Console.WriteLine($"Sorry! Cannot create the report at : {report}");
                    }
                }
                CreateReport(report);
            }
            else
            {
                Console.WriteLine($"This file does not exist at: {csv}");
                Console.ReadLine();
            }
        }
        private static bool ReadFile(string file)
        {
            Console.WriteLine($"Reading data from the file: {file}");
            try
            {
                int fields = 0;
                string[] crimeDataLines = File.ReadAllLines(file);

                for (int arrayIndex = 0; arrayIndex < crimeDataLines.Length; arrayIndex++)
                {
                    string crimeDataLine = crimeDataLines[arrayIndex];
                    string[] data = crimeDataLine.Split(",");

                    // Start
                    if(arrayIndex == 0) 
                    {
                        fields = data.Length;
                    }
                    else
                    {
                        if (fields != data.Length)
                        {
                            Console.WriteLine($"Row {arrayIndex} contains {data.Length} values. It should contain {fields}");
                            return false;
                        }
                        else
                        {
                            try
                            {
                                CrimeData crimeData = new CrimeData();
                                crimeData.Year = Convert.ToInt32(data[0]);
                                crimeData.Population = Convert.ToInt32(data[1]);
                                crimeData.Murders = Convert.ToInt32(data[2]);
                                crimeData.Rapes = Convert.ToInt32(data[3]);
                                crimeData.Robberies = Convert.ToInt32(data[4]);
                                crimeData.ViolentCrimes = Convert.ToInt32(data[5]);
                                crimeData.Thefts = Convert.ToInt32(data[6]);
                                crimeData.MotorVehicleThefts = Convert.ToInt32(data[7]);
                                CrimeDataList.Add(crimeData);
                            }
                            catch(InvalidCastException)
                            {
                                Console.WriteLine($"Row {arrayIndex} contains an invalid value.");
                                return false;
                            }
                        }
                    }   
                }
                Console.WriteLine($"Crime data was read succesfully");
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error reading data from file");
                throw ex;
            }
        }
        private static void CreateReport(string file)
        {
            try
            {
                if(CrimeDataList !=null && CrimeDataList.Any())
                {
                    Console.WriteLine($"Calculating data and writing to report: {file}");
                    StringBuilder sb = new StringBuilder();
                    sb.Append("|||| Crime Analyzer Report ||||");
                    sb.Append("Environment.NewLine");

                    // Calc 1a
                    int minYear = CrimeDataList.Min(i => i.Year);
                    int maxYear = CrimeDataList.Max(i => i.Year);

                    // Calc 1b
                    int years = maxYear - minYear + 1;
                    sb.Append($"Period: {minYear} - {maxYear} ({years} years)");
                    sb.Append(Environment.NewLine);

                    // Calc 2 
                    var mYears = from crimeData in CrimeDataList
                    where crimeData.Murders < 15000
                    select crimeData.Year;
                    string mYearsString = string.Empty;
                    for (int i = 0; i < mYears.Count(); i++)
                    {
                        mYearsString += mYears.ElementAt(i).ToString();
                        if(i < mYears.Count()-1) mYearsString += ",";
                    }
                    sb.Append($"Years murders per year < 15000: {mYearsString}");
                    sb.Append(Environment.NewLine);

                    // Calc 3
                    var robberyYears = from crimeData in CrimeDataList
                    where crimeData.Robberies > 500000
                    select crimeData;
                    string robberyYearsString = string.Empty;
                    for(int i = 0; i < robberyYears.Count(); i++)
                    {
                        CrimeData crimeData = robberyYears.ElementAt(i);
                        robberyYearsString += $"{crimeData.Year} = {crimeData.Robberies}";
                        if (i < robberyYears.Count()-1) robberyYearsString += ",";
                    }
                    sb.Append($"Robberies per year > 5000000: {robberyYearsString}");
                    sb.Append(Environment.NewLine);

                    // Calc 4
                    var vCrime = from crimeData in CrimeDataList
                    where crimeData.Year == 2010
                    select crimeData;
                    CrimeData vCrimeData = vCrime.First();
                    double violentCrimePerCapita = (double)vCrimeData.ViolentCrimes / (double)vCrimeData.Population;
                    sb.Append($"Violent crime per capita rate (2010): {violentCrimePerCapita}");
                    sb.Append(Environment.NewLine);

                    // Calc 5
                    double avgMurders = CrimeDataList.Sum(i => i.Murders) / CrimeDataList.Count;
                    sb.Append($"Average murder per year (all years): {avgMurders}");
                    sb.Append(Environment.NewLine);

                    //Calc 6 
                    int murders1 = CrimeDataList
                    .Where(x => x.Year >= 1994 && x.Year <= 1997)
                    .Sum(y => y.Murders);
                    double avgMurders1 = murders1 / CrimeDataList.Count;
                    sb.Append($"Average murder per year (1994-1997): {avgMurders1}");
                    sb.Append(Environment.NewLine);

                    // Calc 7 
                    int murders2 = CrimeDataList
                    .Where(x => x.Year >= 2010 && x.Year <= 2014)
                    .Sum(y => y.Murders);
                    double avgMurders2 = murders2 / CrimeDataList.Count;
                    sb.Append($"Average murder per year (2010-2014): {avgMurders2}");
                    sb.Append(Environment.NewLine);

                    // Calc 8
                    int minTheft = CrimeDataList
                    .Where(x => x.Year >= 1999 && x.Year <= 2004)
                    .Min(x => x.Thefts);
                    sb.Append($"Minimum thefts per year (1999-2004): {minTheft}");
                    sb.Append(Environment.NewLine);

                    // Calc 9
                    int maxTheft = CrimeDataList
                    .Where(x => x.Year >= 1999 && x.Year <= 2004)
                    .Max(x => x.Thefts);
                    sb.Append($"Maximum thefts per year (1999-2004): {maxTheft}");
                    sb.Append(Environment.NewLine);

                    // Calc 10
                    int yMaxVehicleTheft = CrimeDataList.OrderByDescending(x => x.MotorVehicleThefts).First().Year;
                    sb.Append($"Year of highest number of motor vehicle thefts: {yMaxVehicleTheft}");
                    sb.Append(Environment.NewLine);

                    using (var stream = new StreamWriter(file))
                    {
                        stream.Write(sb.ToString());
                    }

                    Console.WriteLine();
                    Console.WriteLine(sb.ToString());
                    Console.WriteLine();
                    Console.WriteLine($"Report successfully written to: {file}");
                }
                else
                {
                    Console.WriteLine($"No data to create report");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Sorry! There was an error writing report to file");
                throw ex;
            }
        }
    }
}