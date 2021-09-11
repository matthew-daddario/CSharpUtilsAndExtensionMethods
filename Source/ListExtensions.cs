using System.Collections.Generic;
using System.Linq;

namespace Program
{
    public static class ListExtensions
    {
        public static List<T> ObjectToList<T>(this T instance) => new() { instance };

        public static List<List<T>> ChunkBy<T>(this List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}