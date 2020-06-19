using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
namespace Petzold.DrawGraphicsOnBitmap
{
    public class DrawGraphicsOnBitmap : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new DrawGraphicsOnBitmap());
        }
        public DrawGraphicsOnBitmap()
        {
            Title = "Draw Graphics on Bitmap"; // Установка фона для демонстрации прозрачности растрового изображения
            Background = Brushes.Khaki; // Создание объекта RenderTargetBitmap
            RenderTargetBitmap renderbitmap = new RenderTargetBitmap(100, 100, 96, 96, PixelFormats.Default); // Создание DrawingVisual объекта
            DrawingVisual drawvis = new DrawingVisual();
            DrawingContext dc = drawvis.RenderOpen();
            dc.DrawRoundedRectangle(Brushes.Blue, new Pen(Brushes.Red, 10), new Rect(25, 25, 50, 50), 1, 100); // параметры картинки(цвет, форма, положение)
            dc.Close(); // Визуализирование DrawingVisual на RenderTargetBitmap 
            renderbitmap.Render(drawvis); // Создание объекта Image и установка его Source изображения
            Image img = new Image();
            img.Source = renderbitmap; // Объект Image - содержимое окна
            Content = img;
        }
    }
}