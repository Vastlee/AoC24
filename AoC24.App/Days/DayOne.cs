namespace AoC24.Days;

internal class DayOne : Day {
    public int[] FirstList { get; private set; } = [];
    public int[] SecondList { get; private set; } = [];
    
    public DayOne() {
        InitDay(1);
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

    public override void PartOne() {
        int totalDistance = 0;
        int distance;
        int[] firstOrdered = [.. FirstList.Order()];
        int[] secondOrdered = [.. SecondList.Order()];

        for(int i = 0; i < firstOrdered.Length; i++) {
            distance = Math.Abs(firstOrdered[i] - secondOrdered[i]);
            totalDistance += distance;
        }

        Console.WriteLine(totalDistance.ToString());
    }

    public override void PartTwo() {
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

        Console.WriteLine(similarity.ToString());
    }
}
