using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Hadoop.Avro.Container;

namespace AvroConverter
{
    public static class AvroConvert
    {
        public static string ToJson(FileInfo path, Func<string, string> formatter = null) =>
            Using(new FileStream(path.FullName, FileMode.Open, FileAccess.Read, FileShare.Read), s => ToJson(s, formatter));

        public static string ToJson(Stream s, Func<string, string> formatter = null) =>
            s.ToBodies().ToList().ToJsonArray().Format();
        
        private static TR Using<TDisp, TR>(TDisp disposable, Func<TDisp, TR> f) where TDisp : IDisposable
        {
            using (disposable)
            {
                return f(disposable);
            }
        }

        private static IEnumerable<string> ToBodies(this Stream s) => Using(AvroContainer.CreateGenericReader(s), r =>
        {
            var b = new List<string>();
            try
            {
                while (r.MoveNext())
                {
                    b.AddRange(r.Current.ToBody());
                }
            }
            catch (ArgumentOutOfRangeException e) when (e.Message == "Specified argument was out of the range of valid values.\r\nParameter name: size")
            {
                // Ignored (unknown how to avoid MoveNext throwing exception when there is no next block to read)
            }
            return b;
        });

        internal static string ToJsonArray(this IReadOnlyCollection<string> bodies) => bodies.Count > 1 ? "[" + string.Join(",", bodies) + "]" :
            bodies.Count == 1 ? string.Join(",", bodies) : string.Empty;

        internal static string Format(this string json, Func<string, string> formatter = null) => formatter != null ? formatter(json) : json;

        internal static IEnumerable<string> ToBody(this IAvroReaderBlock<object> x) => x.Objects.Cast<dynamic>()
            .Select(record => Encoding.UTF8.GetString(record.Body)).Cast<string>();
    }
}
