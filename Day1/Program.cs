// See https://aka.ms/new-console-template for more information

using System.Text;

var fileName = "C:\\code\\advent-of-code-2023\\Day1\\input.txt";


var lines = File.ReadLines(fileName);
var numbers = new HashSet<char>(new [] {'1','2', '3','4','5','6','7','8','9','0'});
var numbersAsString = new Dictionary<string, string>
{
    {"one", "1"},
    {"two", "2"},
    {"three", "3"},
    {"four", "4"},
    {"five", "5"},
    {"six", "6"},
    {"seven", "7"},
    {"eight", "8"},
    {"nine", "9"}
};

var sum = 0;
var stringb = new StringBuilder();
foreach (var line in lines)
{
    var t = line.Where(numbers.Contains).Aggregate(stringb, (seed, x) => seed.Append(x)).ToString();

    switch (t.Length)
    {
        case > 2:
            t = t.First().ToString() + t.Last();
            break;
        case 1:
            t += t;
            break;
    }
    
    stringb.Clear();
    sum += int.Parse(t);
    ;
}





Console.WriteLine(sum);