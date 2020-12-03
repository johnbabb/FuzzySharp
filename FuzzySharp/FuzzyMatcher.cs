using Microsoft.SqlServer.Server;
namespace FuzzySharp
{
    public partial class FuzzyMatcher
    {
        [SqlFunction(IsDeterministic = true, IsPrecise = false)]
        public static double FuzzyMatch(string input1, string input2)
        {
            return Fuzz.WeightedRatio(input1, input2);
        }
    }
}
