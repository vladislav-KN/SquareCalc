using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareCalc
{
   
    public class Calculator
    {
 
        public IResult ResultHandler;
        public Calculator(IResult resFormat ) 
        {
            ResultHandler = resFormat;
        }

        public Calculator() 
        {
            ResultHandler = new ConsoleResult();
        }

        public void CalculateAreaWithResultHandle(List<IFigure> figures)
        {
            ResultHandler.HandlAreaResult(ClaculateArea(figures));
        }
        public double[] ClaculateArea(List<IFigure> figures)
        {
            double[] result = new double[figures.Count];
            for(int i = 0; i<figures.Count;i++)
            {
                if(figures[i].SquareCanBeCalculated())
                    result[i] = figures[i].Square();
                else
                    result[i] = 0;  
            }
            return result;
        }
    }
}
