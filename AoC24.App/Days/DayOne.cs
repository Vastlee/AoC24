using System.Collections.Generic;

namespace AoC24.Days;

internal class DayOne {
    public static IEnumerable<string> Input { get; } = File.ReadLines("Inputs/DayOneInput.txt");
    public int[] FirstList { get; private set; } = [];
    public int[] SecondList { get; private set; } = [];
    
    public DayOne() {
        FirstList = new int[Input.Count()];
        SecondList = new int[Input.Count()];
        InitializeInput();
    }

    void InitializeInput() {
        int index = 0;
        foreach(string line in Input) {
            int[] split = line
                .Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            FirstList[index] = split[0];
            SecondList[index] = split[1];

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
