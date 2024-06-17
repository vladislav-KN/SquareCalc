using SquareCalc;

namespace FigureTest
{
    public class TriangleTest
    {
        [Fact]
        public void Triangle_SetDifferntExistsTriangles_GetRightSquares()
        {
            Triangle testTriangle1 = new Triangle() {A = 4, B = 3, C = 5 };
            Triangle testTriangle2 = new Triangle() { A = 1, B = 2, C = 2 };
            Triangle testTriangle3 = new Triangle() { A = 26, B = 50, C = 25 };

            Assert.Equal(6, testTriangle1.Square());
            Assert.Equal(0.96824583655185, testTriangle2.Square(), 14);
            Assert.Equal(125.59831806199, testTriangle3.Square(), 11);
        }

        [Fact]
        public void Triangle_SetSidesOfNotExistSquareTriangle_ThrowNotExistException()
        {
            Triangle testTriangle = new Triangle() { A = 1, B = 2, C = 1 };
            Assert.Throws<NotExistException>(() => testTriangle.Square());
        }

        [Fact]
        public void Triangle_SetSidesOfNotExistSquareTriangleBelowZero_ThrowBelowZeroException()
        {
            Assert.Throws<BelowZeroException>(() => { 
                Triangle testTriangle = new Triangle() { A = -1, B = 2, C = 1 }; 
            });
            Assert.Throws<BelowZeroException>(() => {
                Triangle testTriangle = new Triangle() { A = 1, B = 2, C = 1 };
                testTriangle.A = 0;
            });
            Assert.Throws<BelowZeroException>(() => {
                Triangle testTriangle = new Triangle() { A = 1, B = 2, C = 1 };
                testTriangle.A = -1000000000;
            });
        }

        [Fact]
        public void Triangle_SetSidesOfUncalculatebleTriangleAndCallSquareCanBeCalculated_GetFalse()
        {
            Triangle testTriangle1 = new Triangle() { A = 1, B = 2, C = 1 };
            Triangle testTriangle2 = new Triangle() { A = double.MaxValue, B = 2, C = 1 };
            Assert.False(testTriangle1.SquareCanBeCalculated());
            Assert.False(testTriangle2.SquareCanBeCalculated());
        }
        [Fact]
        public void Triangle_SetSidesOfCalculatebleTriangleAndCallSquareCanBeCalculated_GetTrue()
        {
            Triangle testTriangle = new Triangle() { A = 1, B = 1, C = 1 };
           
            Assert.True(testTriangle.SquareCanBeCalculated());
            
        }
        [Fact]
        public void Triangle_SetRectangle_GetTrueAndTwoLeg()
        {
            Triangle testTriangle = new Triangle() { A = 5, B = 4, C = 3 };

            Assert.True(testTriangle.IsRectangle.Item1);
            Assert.Equal(3, testTriangle.IsRectangle.Item2);
            Assert.Equal(4, testTriangle.IsRectangle.Item3);

        }

    }
}