using System;

namespace AoC24;
internal abstract class Day {
    public IEnumerable<string> Input { get; private set; } = [];

    const string LocationDefault = "Inputs/";
    public int DayNumber { get; protected set; }
    public string Location { get; protected set; } = LocationDefault;
    public string FileName { get; protected  set; } = string.Empty;
    public string FilePath => Path.Combine(Location, FileName);

    public void InitDay() {
        FileName = "InputDay" + DayNumber.ToString("D2") + ".txt";
        Input = File.ReadLines(FilePath);
    }
}
