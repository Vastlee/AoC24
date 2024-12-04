using System.Text.RegularExpressions;

namespace AoC24.Days;

internal class DayThree : Day {

    public DayThree(params string[] testInput) {
        if(testInput.Length == 0) { InitDay(3); }
        if(testInput.Length != 0) { Input = testInput; }
    }

    public override void PartOne() {
        string cleanInput = string.Concat(Input);
        string pattern = @"(mul\(\d+,\d+\))";
        Regex rx = new(pattern);
        MatchCollection functions = rx.Matches(cleanInput);
        int total = 0;

        foreach(Match function in functions) {
            total += Multiply(function.Value);
        }

        Console.WriteLine(total);
    }

    public override void PartTwo() {
        string cleanInput = string.Concat(Input);
        string pattern = @"(mul\(\d+,\d+\))|(do\(\)|don't\(\))";
        Regex rx = new(pattern);
        MatchCollection functions = rx.Matches(cleanInput);

        int total = 0;
        bool shouldMultiply = true;
        string functionName;

        foreach(Match function in functions) {
            functionName = FuncName(function.Value);
            if(functionName == "don't") { shouldMultiply = false; }
            if(functionName == "do") { shouldMultiply = true; }

            if(shouldMultiply) {
                if(functionName == "mul") {
                    total += Multiply(function.Value);
                }
            }
        }

        Console.WriteLine(total);
    }

    int Multiply(string function) {
        Regex rx = new(@"\d+");
        MatchCollection digits = rx.Matches(function);
        return int.Parse(digits[0].Value) * int.Parse(digits[1].Value);
    }

    string FuncName(string function) => function.Split('(')[0];
}
