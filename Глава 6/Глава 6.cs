
// ГЛАВА 6 
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.EnterTheGrid
{
    public class EnterTheGrid : Window
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application(); // Инициализация объекта 
            app.Run(new EnterTheGrid());
        }
        public EnterTheGrid()
        {
            Title = "Enter the Grid";
            MinWidth = 300; SizeToContent = SizeToContent.WidthAndHeight; // Create StackPanel for window content.
            StackPanel stack = new StackPanel();
            Content = stack; 
            Grid grid1 = new Grid(); // Область с таблицей
            grid1.Margin = new Thickness(5); // Инициализация новой структуры 
            stack.Children.Add(grid1); 
            for (int i = 0; i < 5; i++)
            {
                RowDefinition rowdef = new RowDefinition(); // Свойства строки
                rowdef.Height = GridLength.Auto;
                grid1.RowDefinitions.Add(rowdef);
            } // Set column definitions.
            ColumnDefinition coldef = new ColumnDefinition(); // Свойства столбца
            coldef.Width = GridLength.Auto;
            grid1.ColumnDefinitions.Add(coldef);
            coldef = new ColumnDefinition();
            coldef.Width = new GridLength(100, GridUnitType.Star);
            grid1.ColumnDefinitions.Add(coldef); // Create labels and text boxes.
            string[] strLabels = { "_First name:", "_Last name:", "_Social security number:", "_Credit card number:", "_Other personal stuff:" };
            for (int i = 0; i < strLabels.Length; i++)
            {
                Label lbl = new Label(); // Текст 
                lbl.Content = strLabels[i];
                lbl.VerticalContentAlignment = VerticalAlignment.Center; // Вертикальное выравнивание 
                grid1.Children.Add(lbl);
                Grid.SetRow(lbl, i);
                Grid.SetColumn(lbl, 0);
                TextBox txtbox = new TextBox(); // Редактор текста
                txtbox.Margin = new Thickness(5);
                grid1.Children.Add(txtbox);
                Grid.SetRow(txtbox, i);
                Grid.SetColumn(txtbox, 1);
            }
            Grid grid2 = new Grid(); 
            grid2.Margin = new Thickness(10);
            stack.Children.Add(grid2); 
            grid2.ColumnDefinitions.Add(new ColumnDefinition());
            grid2.ColumnDefinitions.Add(new ColumnDefinition()); 
            Button btn = new Button();
            btn.Content = "Submit";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.IsDefault = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn); 
            btn = new Button();
            btn.Content = "Cancel";
            btn.HorizontalAlignment = HorizontalAlignment.Center;
            btn.IsCancel = true;
            btn.Click += delegate { Close(); };
            grid2.Children.Add(btn);
            Grid.SetColumn(btn, 1);
            (stack.Children[0] as Panel).Children[1].Focus();
        }
    }
}
