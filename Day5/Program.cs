var lines = File.ReadAllLines("C:\\code\\advent-of-code-2023\\Day5\\input.txt");

var seeds = new List<uint>();

seeds.AddRange(lines[0].Split(' ').Where(x => x.All(char.IsDigit)).Select(uint.Parse));

var previousLineCount = 0;
var seedToSoil = Array.Empty<Map>();
var soiToFertilizer = Array.Empty<Map>();
var fertilizerToWater =  Array.Empty<Map>();
var waterToLight =  Array.Empty<Map>();
var lightToTempruture =  Array.Empty<Map>();
var tempToHumidity =  Array.Empty<Map>();
var humToLocation =  Array.Empty<Map>();

while (previousLineCount + 1 != lines.Length)
{
    var lineBre = lines.Skip(previousLineCount + 2).TakeWhile(x => x != String.Empty).ToArray();
    previousLineCount += lineBre.Length + 1;

    var activeMapping = lineBre
        .Skip(1)
        .Select(line => line
            .Split(' ')
            .Select(uint.Parse)
            .ToArray())
        .Select(split => new Map(split[0], split[1], split[2]))
        .ToArray();
    
    if (lineBre.Any(x => x.Contains("seed-to-soil")))
    { 
        seedToSoil = activeMapping;
    }
    else if (lineBre.Any(x => x.Contains("soil-to-fertilizer")))
    {
        soiToFertilizer = activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("fertilizer-to-water")))
    {
        fertilizerToWater = activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("water-to-light")))
    {
        waterToLight = activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("light-to-temperature")))
    {
        lightToTempruture =activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("temperature-to-humidity")))
    {
        tempToHumidity = activeMapping; 
    }
    else if (lineBre.Any(x => x.Contains("humidity-to-location")))
    {
        humToLocation = activeMapping; 
    }
    
}

var lowest = uint.MaxValue;
foreach (var seed in seeds)
{
    Console.WriteLine($"Searching seed {seed}");

    var soil = Get(seedToSoil, seed);
    var fert = Get(soiToFertilizer,soil);
    var water = Get(fertilizerToWater,fert);
    var light = Get(waterToLight, water);
    var temp = Get(lightToTempruture, light);
    var hum = Get(tempToHumidity, temp);
    var loc = Get(humToLocation, hum);

    if (loc < lowest)
    {
        lowest = loc;
    }

}
Console.WriteLine(lowest)
;
uint Get(Map[] maps, uint i)
{
    foreach (var map in maps)
    {
        if (map.Contains(i))
        {
            Console.WriteLine("Found one val");
            return map[i];
        }
    }

    return i;
}

struct Map
{
    public uint Destination { get; set; }
    public uint Source { get; set; }
    public uint Range { get; set; }

    private uint RangeOfSource => Source + Range;
    public Map(uint destination, uint source, uint range)
    {
        Destination = destination;
        Source = source;
        Range = range;
    }

    public bool Contains(uint i)
    {
        return RangeOfSource >= i && Source < i;
    }
    public uint this[uint i]
    {
        get
        {
            var dest = Enumerable.Range(Destination, Range);
            var src = Enumerable.Range(Source, Range);
            var dict = src.Zip(dest);
            try
            {
                return dict.First(x => x.First == i).Second;

            }
            catch
            {
                Console.WriteLine($"Seed {i} said was in {Source} in range {Range}");
                return i;
            }
        }
    }
}

public static class Enumerable {
    public static IEnumerable<uint> Range(uint start, uint count) {
        var end = start + count;
        for(var current = start; current < end; ++current) {
            yield return current;
        }
    }
}


