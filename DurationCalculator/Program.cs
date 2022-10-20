using DurationCalculator;

FileController fileController=new FileController("Durations.txt");


List<string[]> GradeTimes=fileController.GetGradeTotalTimes();

foreach( var GradeTime in GradeTimes)
{
    Console.WriteLine($"total learning :" + GradeTime[0]);
    Console.WriteLine($"total learning with overhead :" + GradeTime[1]);
    Console.WriteLine($"total learning per week :" + GradeTime[2]);
    Console.WriteLine($"total learning :" + GradeTime[3] + '\n');
}

