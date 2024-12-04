using System.Globalization;
using System.Text;

namespace AoC24;

internal static class AoC24Helpers {
    public static List<T> ToList<T>(this string inStr, char delimiter = ' ') =>
        inStr
        .Split(delimiter, StringSplitOptions.RemoveEmptyEntries)
        .Cast<T>()
        .ToList();

    public static string ToStr(this int[] nums) {
        StringBuilder result = new("{ ");

        for(int i = 0; i < nums.Length; i++) {
            result.Append(nums[i]);
            if(i != nums.Length) { result.Append(","); }
        }
        result.Append(" }");

        return result.ToString();
    }

    public static string ToStr(this List<int> nums) {
        StringBuilder result = new("{ ");

        for(int i = 0; i < nums.Count; i++) {
            result.Append(nums[i]);
            if(i < nums.Count-1) { result.Append(","); }
        }
        result.Append(" }");

        return result.ToString();
    }
}
