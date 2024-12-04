using System;

namespace AoC24;
internal abstract class Day {
    public string[] Input { get; protected set; } = [];

    const string LocationDefault = "Inputs/";
    public int DayNumber { get; protected set; }
    public string Location { get; protected set; } = LocationDefault;
    public string FileName { get; protected  set; } = string.Empty;
    public string FilePath => Path.Combine(Location, FileName);

    public void InitDay(int day) {
        DayNumber = day;
        FileName = "InputDay" + DayNumber.ToString("D2") + ".txt";
        Input = File.ReadAllLines(FilePath);
    }

    public abstract void PartOne();
    public abstract void PartTwo();
}
