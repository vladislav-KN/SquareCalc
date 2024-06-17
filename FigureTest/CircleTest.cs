using SquareCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureTest
{
    public class CircleTest
    {
        [Fact]
        public void Circle_SetDifferntRadiuses_GetRightSquares()
        {
            Circle circle1 = new Circle() { R = 1 };
            Circle circle2 = new Circle() { R = 25 };
            Circle circle3 = new Circle() { R = 110 };
            Assert.Equal(3.14159, circle1.Square(), 5);
            Assert.Equal(1963.49541, circle2.Square(), 5);
            Assert.Equal(38013.27111, circle3.Square(), 5);
        }
        [Fact]
        public void Circle_SetDifferntNegativeRadiuses_ThrowBelowZeroException()
        {
            Assert.Throws<BelowZeroException>(() => {
                Circle circle1 = new Circle() { R = -1 };
            });
            Assert.Throws<BelowZeroException>(() => {
                Circle circle = new Circle() { R = 1 };
                circle.R = 0;
            });
            Assert.Throws<BelowZeroException>(() =>
            {
                Circle circle = new Circle() { R = 1 };
                circle.R = -10;
            });
             
        }
    }
}
