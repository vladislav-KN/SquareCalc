using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace SquareCalc
{
    public class Circle : IFigure
    {
        private double r;
        //Радиус
        public double R { 
            get 
            { 
                return r; 
            } 
            set 
            {
                if (value<=0)
                {
                    throw new BelowZeroException($"Value below zero, Radius = {value}");
                }
                r = value; 
            } 
        }

        /// <summary>
        /// Определяем возможность вычислить площадь круга
        /// </summary>
        /// <returns>Возвращает true если радиус больше 0 или вычисления возможны</returns>
        public bool SquareCanBeCalculated()
        {
            try
            {
                return Math.PI * r * r > 0;
            }
            catch(OverflowException e)
            {
                return false; 
            }
        }
        /// <summary>
        /// Вычисляем площадь круга
        /// </summary>
        /// <returns>Возвращает площадь круга по формуле Pi*R^2</returns>
        public double Square()
        {
            return Math.PI*r*r;
        }
    }
    public class Triangle : IFigure
    {
        private double a;
        private double b;
        private double c;
        //сторона A
        public double A
        {
            get
            {
                return a;
            }
            set
            {
                if (value <= 0)
                {
                    throw new BelowZeroException($"Value below zero, A = {value}");
                }
                a = value;
            }
        }
        //сторона B
        public double B
        {
            get
            {
                return b;
            }
            set
            {
                if (value <= 0)
                {
                    throw new BelowZeroException($"Value below zero, B = {value}");
                }
                b = value;
            }
        }
        //сторона C
        public double C
        {
            get
            {
                return c;
            }
            set
            {
                if (value <= 0)
                {
                    throw new BelowZeroException($"Value below zero, C = {value}");
                }
                c = value;
            }
        }

        //Проверка прямогуольника при обновлении данных. Передает данные о том, что это прямогольнику и 2 катета.
        public Tuple<bool,double,double> IsRectangle 
        { 
            get 
            {
                if (Exist(a, b, c))
                {
                    if (a * a + b * b == c * c)
                    {
                        return new Tuple<bool, double, double>(true, a, b);
                    }
                    else if (c * c + b * b == a * a)
                    {
                        return new Tuple<bool, double, double>(true, c, b);
                    }
                    else if (c * c + b * b == a * a)
                    {
                        return new Tuple<bool, double, double>(true, c, b);
                    }
                }
                return new Tuple<bool, double, double>(false, 0, 0);
            } 
        }

        /// <summary>
        /// Проверка существует ли треугольник 
        /// </summary>
        /// <param name="a">сторона треугольника a</param>
        /// <param name="b">сторона треугольника b</param>
        /// <param name="c">сторона треугольника c</param>
        /// <returns>
        ///     Если сумма 2-х соторон больше третей 
        ///     во всех случаях, возвращает true, иначе false
        /// </returns>
        public static bool Exist(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        /// <summary>
        /// Вычисление площади
        /// </summary>
        /// <returns>
        ///     возвращает площадь треугольника по формуле 
        ///     площади прямоугольного треугольника или 
        ///     по формуле Герона
        /// </returns>
        /// <exception cref="NotExistException">Выбрасывает ошибку если треугольника не существует</exception>
        public double Square()
        {
            if (!Exist(a, b, c))
            {
                throw new NotExistException("Triangle not exist");
            }
            //проверяем треугольник на прямой угол
            if (IsRectangle.Item1)
            {
                return IsRectangle.Item2 * IsRectangle.Item3 / 2;
            }
            double p = Perimeter()/2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
        /// <summary>
        ///     Вычисляем периметр
        /// </summary>
        /// <returns>Возвращает сумму всех сторон</returns>
        public double Perimeter()
        {
            return a + b + c;
        }

        /// <summary>
        /// Проверяем возможность вычисления
        /// </summary>
        /// <returns>Возвращает true если результата вычисления больше 0 или вычисления возможны</returns>
        public bool SquareCanBeCalculated()
        {
            try
            {
                if (IsRectangle.Item1)
                {
                    return IsRectangle.Item2 * IsRectangle.Item3 / 2 > 0;
                }
                double p = Perimeter() / 2;
                return (p * (p - a) * (p - b) * (p - c)) > 0;
            }
            catch (OverflowException e)
            {
                return false;  
            }
        }
    }
}
