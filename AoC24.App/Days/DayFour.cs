namespace AoC24.Days;

internal class DayFour : Day {

    public DayFour(params string[] testInput) {
        if(testInput.Length == 0) { InitDay(4); }
        if(testInput.Length != 0) { Input = testInput; }
    }

    public override void PartOne() {
        int foundCount = 0;
        char[,] matrix = ToCharMatrix(Input);

        for(int i = 0; i < matrix.GetLength(0); i++) {
            for(int i2 = 0; i2 < matrix.GetLength(1); i2++) {
                if(XmasNorth(matrix, i, i2)) { foundCount++; }
                if(XmasNorthEast(matrix, i, i2)) { foundCount++; }
                if(XmasEast(matrix, i, i2)) { foundCount++; }
                if(XmasSouthEast(matrix, i, i2)) { foundCount++; }
                if(XmasSouth(matrix, i, i2)) { foundCount++; }
                if(XmasSouthWest(matrix, i, i2)) { foundCount++; }
                if(XmasWest(matrix, i, i2)) { foundCount++; }
                if(XmasNorthWest(matrix, i, i2)) { foundCount++; }
            }
        }

        Console.WriteLine(foundCount);
    }

    public override void PartTwo() {
        throw new NotImplementedException();
    }

    char[,] ToCharMatrix(string[] input) {
        char[,] result = new char[input.Length, input[0].Length];

        for(int i = 0; i < input.Length; i++) {
            for(int i2 = 0; i2 < input[i].Length; i2++) {
                result[i, i2] = input[i][i2];
            }
        }

        return result;
    }

    bool IsXmas(string input) => input.Equals("XMAS", StringComparison.OrdinalIgnoreCase);
    bool FitsNorth(char[,] matrix, int row, int column) => row - 3 >= 0;
    bool FitsEast(char[,] matrix, int row, int column) => column + 3 < matrix.GetLength(1);
    bool FitsSouth(char[,] matrix, int row, int column) => row + 3 < matrix.GetLength(0);
    bool FitsWest(char[,] matrix, int row, int column) => column - 3 >= 0;

    bool XmasNorth(char[,] matrix, int row, int column) {
        if(!FitsNorth(matrix, row, column)) { return false; }
        string combined = new(new char[] { matrix[row, column], matrix[row - 1, column], matrix[row - 2, column], matrix[row - 3, column] });
        return IsXmas(combined);
    }

    bool XmasNorthEast(char[,] matrix, int row, int column) {
        if(!FitsNorth(matrix, row, column) || !FitsEast(matrix, row, column)) { return false; }
        string combined = new(new char[] { matrix[row, column], matrix[row - 1, column + 1], matrix[row - 2, column + 2], matrix[row - 3, column + 3] });
        return IsXmas(combined);
    }

    bool XmasEast(char[,] matrix, int row, int column) {
        if(!FitsEast(matrix, row, column)) { return false; }
        string combined = new(new char[] { matrix[row, column], matrix[row, column + 1], matrix[row, column + 2], matrix[row, column + 3] });
        return IsXmas(combined);
    }


    bool XmasSouthEast(char[,] matrix, int row, int column) {
        if(!FitsSouth(matrix, row, column) || !FitsEast(matrix, row, column)) { return false; }
        string combined = new(new char[] { matrix[row, column], matrix[row + 1, column + 1], matrix[row + 2, column + 2], matrix[row + 3, column + 3] });
        return IsXmas(combined);
    }

    bool XmasSouth(char[,] matrix, int row, int column) {
        if(!FitsSouth(matrix, row, column)) { return false; }
        string combined = new(new char[] { matrix[row, column], matrix[row + 1, column], matrix[row + 2, column], matrix[row + 3, column] });
        return IsXmas(combined);
    }

    bool XmasSouthWest(char[,] matrix, int row, int column) {
        if(!FitsSouth(matrix, row, column) || !FitsWest(matrix, row, column)) { return false; }
        string combined = new(new char[] { matrix[row, column], matrix[row + 1, column - 1], matrix[row + 2, column - 2], matrix[row + 3, column - 3] });
        return IsXmas(combined);
    }

    bool XmasWest(char[,] matrix, int row, int column) {
        if(!FitsWest(matrix, row, column)) { return false; }
        string combined = new(new char[] { matrix[row, column], matrix[row, column - 1], matrix[row, column - 2], matrix[row, column - 3] });
        return IsXmas(combined);
    }

    bool XmasNorthWest(char[,] matrix, int row, int column) {
        if(!FitsNorth(matrix, row, column) || !FitsWest(matrix, row, column)) { return false; }
        string combined = new(new char[] { matrix[row, column], matrix[row - 1, column - 1], matrix[row - 2, column - 2], matrix[row - 3, column - 3] });
        return IsXmas(combined);
    }
}
