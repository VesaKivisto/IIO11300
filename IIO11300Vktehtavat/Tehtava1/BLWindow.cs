using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tehtava1
{
    public class BusinessLogicWindow
    {
        /// <summary>
        /// CalculatePerimeter calculates the perimeter of a window
        /// </summary>
        public static double CalculatePerimeter(double width, double height)
        {
            double framePerimeter = (width * 2 + height * 2) / 1000;
            return framePerimeter;
        }

        public static double CalculateWindowArea(double width, double height)
        {
            double windowArea = (width * height) / 1000000;
            return windowArea;
        }

        public static double CalculateFrameArea(double width, double height, double frameWidth)
        {
            double frameArea = ((2 * frameWidth + height) * (2 * frameWidth + width) - (width * height)) / 1000000;
            return frameArea;
        }
    }
}
