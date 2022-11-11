using System.Security.AccessControl;
using System.Security.Cryptography;

namespace ShapeLib
{
    public interface Shape
    {
        abstract double Area();
    }
    public class Circle:Shape
    {
        private double R;
        public Circle(double r)
        {
            if (r > 0)
                R = r;
            else throw new ArgumentException("Радиус должен быть больше 0");
        }
        /// <summary>
        /// Вычисление площади круга
        /// </summary>
        /// <param name="R">Радиус круга</param>
        /// <returns>Площадь круга</returns>
        /// <exception cref="ArgumentException">Радиус не может быть меньше 0</exception>
        public double Area()
        {
            return Math.PI * Math.Pow(R, 2);
        }  

    }
    public class Triangle : Shape
    {
        private double A, B, C;

        public Triangle(double a, double b, double c)
        {
            if (LessZero_Sides(a, b, c))
            {
                A = a;
                B = b;
                C = c;
            }
            else throw new ArgumentException("Сторона треугольника должна быть больше 0");
        }
        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        /// <param name="a">Сторона А</param>
        /// <param name="b">Сторона B</param>
        /// <param name="c">Сторона C</param>
        /// <returns>Площадь треугольника</returns>
        /// <exception cref="ArgumentException">Сторона треугольника не может быть меньше 0</exception>
        public double Area()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public bool Check90Angle()
        {
            if (!CheckAllSidesEquals())
            {
                double result1 = Math.Pow(A, 2) + Math.Pow(B, 2) - Math.Pow(C, 2),
                       result2 = Math.Pow(A, 2) + Math.Pow(C, 2) - Math.Pow(B, 2),
                       result3 = Math.Pow(C, 2) + Math.Pow(B, 2) - Math.Pow(A, 2);
                if (result1 == 0 || result2 == 0 || result3 == 0)
                    return true;
            }
            return false;
        }

        private bool CheckAllSidesEquals()
        {
            if (A == B && B == C)
                return true;
            else return false;
        }
        private bool LessZero_Sides(double a, double b, double c)
        {
            if (Math.Min(Math.Min(a, b), c) > 0)
                return true;
            else return false;
        }
    }

    //Насчет задания 
    //Вычисление площади фигуры без знания типа фигуры в compile-time
    //не совсем понятно как это будет изначально задано

    //То есть
    //При вычислении площади фигур с 4 и более сторонами необходимо
    //Разбить фигуру на треугольники
    //Вычислить площадь всех треугольников
    //Сложить площади всех треугольников

    //Перед разбивкой фигуры на треугольники необходимо вычислить 
    //все стороны и углы многоугольника, тогда можно сделать разбивку на треугольники  
    /*
    class Polygon : Shape
    {
        private double[] Sides;
        public Polygon(params double[] sides)
        {
            if (LessZero_Sides(sides))
                Sides = sides;
            else throw new ArgumentException();
        }
        private bool LessZero_Sides(params double[] sides)
        {
            foreach (var side in sides)
                if (side <= 0)
                    return false;
            return true;
        }
    }*/
}

//Задание #2
//Решается запросом LEFT JOIN
//Напримеру
//
// SELECT Product, Category
// FROM catalog LEFT OUTER JOIN category
// ON catalog.id_category = category.id
