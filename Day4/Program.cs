var allLines = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day4\\input.txt");
var cummulativeScore = 0;

foreach (var line in allLines)
{
    var spl = line.Split(new[] {':', '|'});
    var winningNumbers = spl[1].Split(' ').Select(x => int.TryParse(x, out var r) ? (int?)r: null ).Where(x => x is not null).ToArray();
    var ownNumbers = spl[2].Split(' ').Select(x => int.TryParse(x, out var r) ? (int?)r: null ).Where(x => x is not null).ToHashSet();

    var score = 0;
    foreach (var winningNumber in winningNumbers)
    {
        if (ownNumbers.Contains(winningNumber))
        {
            if (score == 0)
            {
                score = 1;
            }
            else
            {
                score *= 2;
            }
        }

        
    }
    cummulativeScore += score;
}
Console.WriteLine(cummulativeScore);