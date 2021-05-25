using System;

namespace Prototype
{
    class Program{
        public static void Run()
        {
            IFigure figure = new Rectangle(10, 20);
            IFigure clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();

            figure = new Circle(10);
            clonedFigure = figure.Clone();
            figure.GetInfo();
            clonedFigure.GetInfo();
        }
    }

    class Circle : IFigure
    {
        int radius;

        public Circle(int r)
        {
            radius = r;
        }

        public IFigure Clone() => new Circle(radius);
        public void GetInfo() => Console.WriteLine("Круг радиусом {0}", radius);
    }

    class Rectangle : IFigure
    {
        int width;
        int height;

        public Rectangle(int w, int h)
        {
            width = w;
            height = h;
        }

        public IFigure Clone() => new Rectangle(width, height);
        public void GetInfo() => Console.WriteLine("Прямоугольник длиной {0} и шириной {1}", height, width);
    }

    interface IFigure
    {
        IFigure Clone();
        void GetInfo();
    }
}