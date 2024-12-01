using System.Collections.Generic;

namespace AoC24.Days;

internal class DayOne {
    const string InputDelemiter = "   ";
    public static IEnumerable<string> Input { get; } = File.ReadLines("Inputs/DayOneInput.txt");
    public int[] FirstList { get; private set; } = [];
    public int[] SecondList { get; private set; } = [];
    public Dictionary<int, string> test = [];
    
    public DayOne() {
        FirstList = new int[Input.Count()];
        SecondList = new int[Input.Count()];
        InitializeInput();
    }

    void InitializeInput() {
        int index = 0;
        foreach(string line in Input) {
            string[] split = line.Split(InputDelemiter);
            FirstList[index] = int.Parse(split[0]);
            SecondList[index] = int.Parse(split[1]);
            index++;
        }
    }

    public int PartOne() {
        int totalDistance = 0;
        int distance;
        int[] firstOrdered = [.. FirstList.Order()];
        int[] secondOrdered = [.. SecondList.Order()];

        for(int i = 0; i < firstOrdered.Length; i++) {
            distance = Math.Abs(firstOrdered[i] - secondOrdered[i]);
            totalDistance += distance;
        }

        return totalDistance;
    }

    public int PartTwo() {
        int similarity = 0;
        int matchCount = 0;
        Dictionary<int, int> used = [];

        foreach(int number in FirstList) {
            if(!used.TryGetValue(number, out matchCount)) {
                matchCount = SecondList.Count(x => x == number);
                used.Add(number, matchCount);
            }
            similarity += number * matchCount;
        }

        return similarity;
    }
}
