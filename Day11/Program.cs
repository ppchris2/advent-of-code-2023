
using System.Drawing;
using System.Text;

var file = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day11\\input.txt");


var test = new StringBuilder();

foreach (var columnIndex in Enumerable.Range(0, file.Length))
{
    var column = file.Aggregate(new StringBuilder(), (seed, acc)  => seed.Append(acc[columnIndex])).ToString();

    if (!column.Contains('#'))
    {
        test.AppendLine(column);
        test.AppendLine(column);
    }
    else
    {
        test.AppendLine(column);
    }
}

var flippedExpandedString = test.ToString().Split('\n').Where(x => x != string.Empty);
test.Clear();

foreach (var columnIndex in Enumerable.Range(0, file.Length))
{
    var column = flippedExpandedString.Aggregate(new StringBuilder(), (seed, acc)  => seed.Append(acc[columnIndex])).ToString();

    if (!column.Contains('#'))
    {
        test.AppendLine(column);
        test.AppendLine(column);
    }
    else
    {
        test.AppendLine(column);
    }
}

var expandedGalaxy = test.ToString();

var line = 0;
var position = 0;
var galaxies = new List<(int, Point)>();
var galaxyIndex = 0;
foreach (var galaxyLine in expandedGalaxy.Split('\n'))
{
    
    foreach (var pos in galaxyLine)
    {
        if (pos == '#')
        {
            galaxies.Add((++galaxyIndex, new Point(position, line)));
        }

        position++;
    }

    position = 0;
    line++;
}

var query = galaxies.SelectMany((value, index) => galaxies.Skip(index + 1),
    (first, second) => new {One = first, Two = second}).ToArray();

double dis = 0;
foreach (var t in query)
{
    var (x1, x2) = (t.One.Item2.X, t.Two.Item2.X);
    var (y1, y2) = (t.One.Item2.Y, t.Two.Item2.Y);

    dis += GetDistance(x1, y1, x2, y2);
}

;
// ....1........
// .........2...
// 3............
// .............
// .............
// ........4....
// .5...........
// .##.........6
// ..##.........
// ...##........
// ....##...7...
// 8....9.......


static double GetDistance(double x1, double y1, double x2, double y2)
{
    return Math.Abs(x2 - x1) + Math.Abs(y2 - y1); //Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
}
