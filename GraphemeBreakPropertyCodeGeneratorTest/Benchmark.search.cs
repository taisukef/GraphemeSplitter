﻿using System.Linq;

namespace GraphemeSplitter
{
    public partial class Benchmark
    {
        static GraphemeBreakProperty GetByLinearSearch(int value) => GetByLinearSearch(Items, value);
        static GraphemeBreakProperty GetByBinarySearch(int value) => GetByBinarySearch(Items, value);

        static GraphemeBreakProperty GetByLinearSearch(PropertyItem[] ranges, int value)
        {
            var f = ranges.FirstOrDefault(r => r.Min <= value && value <= r.Max);
            if (f.Min == 0) return GraphemeBreakProperty.Invalid;
            else return f.Property;
        }

        static GraphemeBreakProperty GetByBinarySearch(PropertyItem[] ranges, int value)
        {
            int lower = 0;
            int upper = ranges.Length - 1;

            while (lower <= upper)
            {
                int middle = lower + (upper - lower) / 2;
                var r = ranges[middle];
                if (value < r.Min) upper = middle - 1;
                else if (value > r.Max) lower = middle + 1;
                else return r.Property;
            }

            return GraphemeBreakProperty.Invalid;

        }
    }
}
