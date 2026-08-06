namespace UlearnCourse.BasicsOfOOP
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Avalonia.Media;
    using Geometry;

    namespace GeometryPainting
    {
        public static class SegmentExtensions
        {
            private static Dictionary<Segment, Avalonia.Media.Color> _dic = new Dictionary<Segment, Avalonia.Media.Color>();

            public static void SetColor(this Segment s, Avalonia.Media.Color color)
            {
                if (_dic.ContainsKey(s))
                    _dic[s] = color;
                else
                    _dic.Add(s, color);
            }

            public static Avalonia.Media.Color GetColor(this Segment s)
            {
                if (_dic.ContainsKey(s))
                    return _dic[s];
                else
                    return Colors.Black;
            }
        }
    }
}