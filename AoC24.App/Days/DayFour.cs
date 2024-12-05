using System.Diagnostics.Tracing;

namespace AoC24.Days;

internal class DayFour : Day {
    char[,] wordSearch;

    public DayFour(params string[] testInput) {
        if(testInput.Length == 0) { InitDay(4); }
        if(testInput.Length != 0) { Input = testInput; }
        wordSearch = ToCharMatrix(Input);

    }

    public override void PartOne() {
        int foundCount = 0;

        for(int i = 0; i < wordSearch.GetLength(0); i++) {
            for(int i2 = 0; i2 < wordSearch.GetLength(1); i2++) {
                if(XmasNorth(i, i2)) { foundCount++; }
                if(XmasNorthEast(i, i2)) { foundCount++; }
                if(XmasEast(i, i2)) { foundCount++; }
                if(XmasSouthEast(i, i2)) { foundCount++; }
                if(XmasSouth(i, i2)) { foundCount++; }
                if(XmasSouthWest(i, i2)) { foundCount++; }
                if(XmasWest(i, i2)) { foundCount++; }
                if(XmasNorthWest(i, i2)) { foundCount++; }
            }
        }

        Console.WriteLine(foundCount);

        bool XmasNorth(int row, int column) {
            if(!FitsNorth(row, 3)) { return false; }
            string combined = new(new char[] { wordSearch[row, column], wordSearch[row - 1, column], wordSearch[row - 2, column], wordSearch[row - 3, column] });
            return IsXmas(combined);
        }

        bool XmasNorthEast(int row, int column) {
            if(!FitsNorth(row, 3) || !FitsEast(column, 3)) { return false; }
            string combined = new(new char[] { wordSearch[row, column], wordSearch[row - 1, column + 1], wordSearch[row - 2, column + 2], wordSearch[row - 3, column + 3] });
            return IsXmas(combined);
        }

        bool XmasEast(int row, int column) {
            if(!FitsEast(column, 3)) { return false; }
            string combined = new(new char[] { wordSearch[row, column], wordSearch[row, column + 1], wordSearch[row, column + 2], wordSearch[row, column + 3] });
            return IsXmas(combined);
        }


        bool XmasSouthEast(int row, int column) {
            if(!FitsSouth(row, 3) || !FitsEast(column, 3)) { return false; }
            string combined = new(new char[] { wordSearch[row, column], wordSearch[row + 1, column + 1], wordSearch[row + 2, column + 2], wordSearch[row + 3, column + 3] });
            return IsXmas(combined);
        }

        bool XmasSouth(int row, int column) {
            if(!FitsSouth(row, 3)) { return false; }
            string combined = new(new char[] { wordSearch[row, column], wordSearch[row + 1, column], wordSearch[row + 2, column], wordSearch[row + 3, column] });
            return IsXmas(combined);
        }

        bool XmasSouthWest(int row, int column) {
            if(!FitsSouth(row, 3) || !FitsWest(column, 3)) { return false; }
            string combined = new(new char[] { wordSearch[row, column], wordSearch[row + 1, column - 1], wordSearch[row + 2, column - 2], wordSearch[row + 3, column - 3] });
            return IsXmas(combined);
        }

        bool XmasWest(int row, int column) {
            if(!FitsWest(column, 3)) { return false; }
            string combined = new(new char[] { wordSearch[row, column], wordSearch[row, column - 1], wordSearch[row, column - 2], wordSearch[row, column - 3] });
            return IsXmas(combined);
        }

        bool XmasNorthWest(int row, int column) {
            if(!FitsNorth(row, 3) || !FitsWest(column, 3)) { return false; }
            string combined = new(new char[] { wordSearch[row, column], wordSearch[row - 1, column - 1], wordSearch[row - 2, column - 2], wordSearch[row - 3, column - 3] });
            return IsXmas(combined);
        }

        bool IsXmas(string input) => input.Equals("XMAS", StringComparison.OrdinalIgnoreCase);
        bool FitsNorth(int row, int dist) => row - dist >= 0;
        bool FitsEast(int column, int dist) => column + dist < wordSearch.GetLength(1);
        bool FitsSouth(int row, int dist) => row + dist < wordSearch.GetLength(0);
        bool FitsWest(int column, int dist) => column - dist >= 0;
    }

    public override void PartTwo() {
        int foundCount = 0;
        char tl, tr, bl, br;

        for(int i = 1; i < wordSearch.GetLength(0) - 1; i++) {
            for(int i2 = 1; i2 < wordSearch.GetLength(1) - 1; i2++) {
                if(wordSearch[i, i2] == 'A') {
                    tl = wordSearch[i - 1, i2 - 1];
                    tr = wordSearch[i - 1, i2 + 1];
                    bl = wordSearch[i + 1, i2 - 1];
                    br = wordSearch[i + 1, i2 + 1];

                    if(IsMasRightToLeft(tl, br) && IsMasLeftToRight(tr, bl)) { foundCount++; }
                }
            }
        }

        Console.WriteLine($"{foundCount}");

        static bool IsMasRightToLeft(char topLeft, char bottomRight) => (topLeft == 'M' && bottomRight == 'S') || (topLeft == 'S' && bottomRight == 'M');

        static bool IsMasLeftToRight(char topRight, char bottomLeft) => (bottomLeft == 'M' && topRight == 'S') || (bottomLeft == 'S' && topRight == 'M');
    }

    static char[,] ToCharMatrix(string[] input) {
        char[,] result = new char[input.Length, input[0].Length];

        for(int i = 0; i < input.Length; i++) {
            for(int i2 = 0; i2 < input[i].Length; i2++) {
                result[i, i2] = input[i][i2];
            }
        }

        return result;
    }
}
