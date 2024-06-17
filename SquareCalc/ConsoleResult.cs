namespace SquareCalc
{
    public class ConsoleResult : IResult
    {
        public void HandlAreaResult(double[] areas)
        {
            foreach(double area in areas)
            {
                Console.WriteLine(area);    
            }
        }
    }
}