using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace Petzold.DesignAButton
{
    public class DesignAButton : Window
    {
        [STAThread] public static void Main()
        {
            Application app = new Application(); // Инициализация объекта 
            app.Run(new DesignAButton());
        }
        public DesignAButton()
        {
            Title = "Design a Button"; // Создание кнопки как содержимое окна 
            Button btn = new Button(); // Инициализация кнопки 
            btn.HorizontalAlignment = HorizontalAlignment.Center; // Центрирование
            btn.VerticalAlignment = VerticalAlignment.Center;
            btn.Click += ButtonOnClick; // Действие при нажатии 
            Content = btn;
            StackPanel stack = new StackPanel(); // Выравнивание
            btn.Content = stack;
            stack.Children.Add(ZigZag(10));
            Uri uri = new Uri("pack://application: ,,/BOOK06.ICO");
            BitmapImage bitmap = new BitmapImage(); // Объект для загрузки изображений
            Image img = new Image(); // Изображение
            img.Margin = new Thickness(0, 10, 0, 0); // Описание поля
            img.Source = bitmap;
            img.Stretch = Stretch.None; // Изменение размеров
            stack.Children.Add(img);
            Label lbl = new Label(); // Лейбл с текстом
            lbl.Content = "_Read books!";
            lbl.HorizontalContentAlignment = HorizontalAlignment.Center; // Ыыравнивание по горизонтали 
            stack.Children.Add(lbl); 
            stack.Children.Add(ZigZag(0));
        }
        Polyline ZigZag(int offset) // Рисование
        {
            Polyline poly = new Polyline();
            poly.Stroke = SystemColors.ControlTextBrush;
            poly.Points = new PointCollection();
            for (int x = 0; x <= 100; x += 10)
                poly.Points.Add(new Point(x, (x + offset) % 20));
            return poly;
        }
        void ButtonOnClick(object sender, RoutedEventArgs args)
        {
            MessageBox.Show("The button has been clicked", Title);
        }
    }
}