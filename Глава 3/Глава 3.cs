using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Petzold.ShapeAnEllipse {
    class ShapeAnEllipse : Window { [STAThread] // Объявление класса
        public static void Main()  
        {
            Application app = new Application(); // Инициализация объекта
            app.Run(new ShapeAnEllipse());
        }
        public ShapeAnEllipse()
        {
            Title = "Shape an Ellipse";
            Ellipse elips = new Ellipse(); // Инициализация эллипса
            elips.Fill = Brushes.AliceBlue;
            elips.StrokeThickness = 24; // Описание эллипса
            elips.Stroke = new LinearGradientBrush(Colors.CadetBlue, Colors.Chocolate, new Point(1, 0), new Point(0, 1));
            Content = elips;
        }
    }
}