

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

//Part 1 
// var sum = 0;
// var stringb = new StringBuilder();
// foreach (var line in lines)
// {
//     var t = line.Where(numbers.Contains).Aggregate(stringb, (seed, x) => seed.Append(x)).ToString();
//
//     switch (t.Length)
//     {
//         case > 2:
//             t = t.First().ToString() + t.Last();
//             break;
//         case 1:
//             t += t;
//             break;
//     }
//     
//     stringb.Clear();
//     sum += int.Parse(t);
//     ;
// }
//

//Part 2
    var sum = 0;
    var characters = new List<char>();
    var listOfNumbers = new List<int>();

    foreach (var line in lines)
    {
     
        foreach (var cha in line)
        {
            if (char.IsDigit(cha))
            {
                listOfNumbers.Add(int.Parse(cha.ToString()));
                characters.Clear();
            }
            else
            {
                characters.Add(cha);
                var myString = new string(characters.ToArray());


                var match = numbersAsString.Keys.SingleOrDefault(x => myString.Contains(x));
                if(match != null)
                {
                    var num = numbersAsString[match];
                
                    listOfNumbers.Add(int.Parse(num));
                    characters = characters.Slice(characters.Count - 1, 1);

                }
            }
            
        }

        sum += int.Parse(listOfNumbers.First().ToString() + listOfNumbers.Last());
        listOfNumbers.Clear();
    }




Console.WriteLine(sum);