using DurationCalculator;

FileController fileController=new FileController("Durations.txt");

List<string> GradeTimes=fileController.GetGradeTotalTimes();

for(int i=0;i<GradeTimes.Count;i++)
{
    Console.WriteLine($"Level{i+1}: " + GradeTimes[i]);
}

