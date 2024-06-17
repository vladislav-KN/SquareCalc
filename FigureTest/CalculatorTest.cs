using Microsoft.VisualStudio.TestPlatform.TestHost;
using SquareCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureTest
{
    public class CalculatorTest
    {
        [Fact]
        public void Calculate_SetDifferntFigures_GetArrayesWithSquares()
        {
            Calculator calculator = new Calculator();
            List<IFigure> figures = new List<IFigure>() {
                new Triangle() { A = 4, B = 3, C = 5 },
                new Circle() { R = 2 },
                new Circle() { R = 100 }
            };
            double[] result = calculator.ClaculateArea(figures);
            Assert.Equal(3, result.Length);
            Assert.Equal(6, result[0]);
            Assert.Equal(12.56637, result[1],5);
            Assert.Equal(31415.92654, result[2],5);
        }
        [Fact]
        public void Calculate_SetDifferntFiguresUncalcFigures_GetArrayesWithZeroes()
        {
            Calculator calculator = new Calculator();
            List<IFigure> figures = new List<IFigure>() {
                new Triangle() { A = 25, B = 12, C = 12 },
                new Triangle() { A = 11, B = 1, C = 1 },
                new Triangle() { A = 1, B = 2, C = 1 },
            };
            double[] result = calculator.ClaculateArea(figures);
            Assert.Equal(3, result.Length);
            Assert.Equal(0, result[0]);
            Assert.Equal(0, result[1]);
            Assert.Equal(0, result[2]);
        }
 
    }
}
