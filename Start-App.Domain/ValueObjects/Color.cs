/*
 * Copyright(c) Trickyrat All Rights Reserved.
 * Licensed under the MIT LICENSE.
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Start_App.Domain.Common;
using Start_App.Domain.Exceptions;

namespace Start_App.Domain.ValueObjects
{
    public class Color : ValueObject
    {
        static Color()
        {
        }

        private Color()
        {
        }

        private Color(string code)
        {
            Code = code;
        }

        public static Color From(string code)
        {
            var Color = new Color { Code = code };

            if (!SupportedColors.Contains(Color))
            {
                throw new UnspportedColorException(code);
            }

            return Color;
        }

        public static Color White => new Color("#FFFFFF");

        public static Color Red => new Color("#FF5733");

        public static Color Orange => new Color("#FFC300");

        public static Color Yellow => new Color("#FFFF66");

        public static Color Green => new Color("#CCFF99 ");

        public static Color Blue => new Color("#6666FF");

        public static Color Purple => new Color("#9966CC");

        public static Color Grey => new Color("#999999");

        public string Code { get; private set; }

        public static implicit operator string(Color Color)
        {
            return Color.ToString();
        }

        public static explicit operator Color(string code)
        {
            return From(code);
        }

        public override string ToString()
        {
            return Code;
        }

        protected static IEnumerable<Color> SupportedColors
        {
            get
            {
                yield return White;
                yield return Red;
                yield return Orange;
                yield return Yellow;
                yield return Green;
                yield return Blue;
                yield return Purple;
                yield return Grey;
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Code;
        }
    }
}
