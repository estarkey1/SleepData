// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();

if (resp == "1")
{
    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
        // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
        // random number generator
    Random rnd = new Random();
       // create file
    StreamWriter sw = new StreamWriter("data.txt");

    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // MMM/dd/yyyy,#|#|#|#|#|#|#
        sw.WriteLine($"Week of {dataDate:MMM dd, yyyy}");
        sw.WriteLine($"{string.Join("| ", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
    sw.Close();
}
else if (resp == "2")
{
    String line;
    StreamReader sr = new StreamReader("data.txt");
    line = sr.ReadLine();
    // Loop through the data text file
    while (line != null)
    {
        // Write the line to the console window
        Console.WriteLine(line);
        line = sr.ReadLine();

        // Day markers
        Console.WriteLine(" Su Mo Tu We Th Fr Sa");
        Console.WriteLine(" -- -- -- -- -- -- --");

        // Hours
        Console.WriteLine($" {line}");
        
        line = sr.ReadLine();
        Console.WriteLine();
    }
    // Close the file
    sr.Close();
    Console.ReadLine();
}
