using System.Drawing;
using System.Numerics;

var example1 = @"-L|F7
7S-7|
L|7||
-L-J|
L|-JF";

var example2 = @"7-F7-
.FJ|7
SJLL7
|F--J
LJ.LJ";



//var lines = example2
//    .Split('\n')
//    .ToArray();

var lines = File.ReadAllLines("C:\\Users\\ppchr\\source\\repos\\advent-of-code-2023\\Day10\\input.txt");

var line = Array.FindIndex(lines, x => x.Contains("S"));
var startingPoint = lines[line].ToArray();
var position = Array.FindIndex(startingPoint, x => x=='S');

int distance = 0;
TraverseDepthFirst(new Point(line, position), lines, null);

Console.WriteLine(distance);

int TraverseDepthFirst(Point currentPosition, string[] matrix, Point? previousPosition)
{
    var currentTile = matrix[currentPosition.X][currentPosition.Y];
    
    if (currentTile == 'S' && distance != 0)
    {
        return distance;
    }

    var steps = GetPossibleNextSteps(currentTile, currentPosition)
        .Where(x => x != previousPosition &&
        x.X >= 0 &&
        x.Y >= 0 &&
        x.X < matrix.Length &&
        x.Y < matrix[0].Length &&
        matrix[x.X][x.Y] != '.' );
    distance++;
    

    foreach (var step in steps)
    {
        return TraverseDepthFirst(step, matrix, currentPosition);
    }
    throw new Exception();
}

Point[] GetPossibleNextSteps(char currentTile, Point currentPosition)
{
    Point katw = new Point(currentPosition.X + 1, currentPosition.Y);
    Point panw = new Point(currentPosition.X - 1, currentPosition.Y);
    Point deksia = new Point(currentPosition.X, currentPosition.Y + 1);
    Point aristera = new Point(currentPosition.X, currentPosition.Y - 1);
    switch (currentTile)
    {
        case 'S':
            return new[] { 
                panw, katw, deksia, aristera
            };
        case '-':
            return new[] {
                deksia, aristera
            };
        case '|':
            return new[] {
                panw, katw
            };
        case 'L':
            return new[] {
                panw, deksia
            };
        case 'J':
            return new[] {
                panw, aristera
            };
        case '7':
            return new[] {
                aristera, katw
            };
        case 'F':
            return new[] {
                deksia, katw
            };
        default:
            return Array.Empty<Point>();
    }

}