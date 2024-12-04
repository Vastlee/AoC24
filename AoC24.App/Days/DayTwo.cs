namespace AoC24.Days;

internal class DayTwo : Day {
    enum ReportDirection { Increasing, Decreasing }

    List<List<int>> reports = [];

    public DayTwo(params string[] testInput) {
        if(testInput.Length == 0) { InitDay(2); }
        if(testInput.Length != 0) { Input = testInput; }

        reports = Input
            .Select(report => report
                .Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList()).ToList();
    }

    public override void PartOne() => Console.WriteLine(TotalSafeReports().ToString());

    public override void PartTwo() => Console.WriteLine(TotalSafeReports(1).ToString());

    ReportSafetyData IsSafe(List<int> report) {
        const int MinDiff = 1;
        const int MaxDiff = 3;

        ReportDirection direction = GetDirection(report[0], report[1]);

        for(int i = 0; i < report.Count - 1; i++) {
            if(GetDirection(report[i], report[i + 1]) != direction) {
                return new(false, i + 1);
            }

            if(!IsSafeDifference(Difference(report[i], report[i + 1]))) {
                return new(false, i + 1);
            }
        }

        return new ReportSafetyData(true, 0);

        ReportDirection GetDirection(int first, int second) => ((first - second) < 0)
            ? ReportDirection.Increasing
            : ReportDirection.Decreasing;

        bool IsSafeDifference(int difference) => difference >= MinDiff && difference <= MaxDiff;
        int Difference(int first, int second) => Math.Abs(first - second);
    }

    public int TotalSafeReports(int allowances = 0) {
        int safeReports = 0;

        ReportSafetyData safeCheck = new(false, 0);

        foreach(List<int> report in reports) {
            safeCheck = IsSafe(report);

            if(!safeCheck.IsSafe) {
                Console.WriteLine($"{report.ToStr()} Failed First Check!");
                if(allowances == 1) {
                    Console.WriteLine($"Removing Index {safeCheck.FailIndex} [{ report.ElementAt(safeCheck.FailIndex)}]");
                    report.RemoveAt(safeCheck.FailIndex);
                    safeCheck = IsSafe(report);

                    if(!IsSafe(report).IsSafe) {
                        Console.WriteLine($"{report.ToStr()} Failed Final Check!");
                        continue;
                    }
                }
                continue;
            }
            safeReports++;
        }

        return safeReports;
    }

    record struct ReportSafetyData(bool IsSafe, int FailIndex);
}
