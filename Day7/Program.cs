var example = @"32T3K 765
T55J5 684
KK677 28
KTJJT 220
KK5JJ 483";

var input = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day7\\input.txt");

var games = example.Split('\n').Select(x =>
{
    var y = x.Split(' ').ToArray();
    return new Game() {Hand = y[0], Bid = int.Parse(y[1])};
});

var groups = games.GroupBy(x => x.FindType()).OrderByDescending(x => x.Key);
var rank = 1;
var result = 0;
foreach (var group in groups)
{
    var t = group.OrderByDescending(x => x.Hand, new Comp()).ToArray();
    foreach (var tt in t)
    {
        result += rank++ * tt.Bid;

    }
}
Console.WriteLine(result);

public class Comp : IComparer<string>
{
    public static List<char> Order = new List<char>
    {
        'A',
        'K',
        'Q',
        'J',
        'T',
        '9',
        '8',
        '7',
        '6',
        '5',
        '4',
        '3',
        '2'
    };
    
    public int Compare(string? x, string? y)
    {
        foreach (var cha in x.Zip(y))
        {
            if (Order.IndexOf(cha.First) == Order.IndexOf(cha.Second))
            {
                continue; 
            }
            if (Order.IndexOf(cha.First) > Order.IndexOf(cha.Second))
            {
                return 1;
                
            }

            return -1;
        }

        return 0;
    }
}

class Game
{
    public string Hand { get; set; }
    public int Bid { get; set; }
    
    
    
    // public int FindScore
    // {
    //     get
    //     {
    //     
    //         var score = 0;
    //         foreach (var cha in Hand)
    //         {
    //             score += Order.IndexOf(cha);
    //         }
    //
    //         return score;
    //     }
    // }

    public Types FindType()
    {
        // 32T3K one pair
        var doublePairs = Hand.GroupBy(c => c).Where(g=>g.Count() == 2).ToArray();
        var groups = Hand.GroupBy(c => c).Max(g=>g.Count());
        return groups switch
        {
            5 => Types.FiveOfKind,
            4 => Types.FourOfKind,
            3 => Types.ThreeOfKind,
            2  when doublePairs.Count() == 2 => Types.TwoPair,
            2 when doublePairs.Count() == 1 => Types.OnePair,
            _ => Types.NoPair
        };
    }
    
}

enum Types
{
    FiveOfKind,
    FourOfKind,
    ThreeOfKind,
    TwoPair,
    OnePair,
    NoPair
}
enum HandStrengths
{
    // A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, 2
    
    
}