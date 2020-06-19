using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.ListColorNames {
    class ListColorNames : Window {
        [STAThread]
        public static void Main()  {
            Application app = new Application(); // Инициализация объекта 
            app.Run(new ListColorNames());
        }
        public ListColorNames()         {
            Title = "List Color Names"; // Создание ListBox как содержимое окна           
            ListBox lstbox = new ListBox();
            lstbox.Width = 150; // Параметры здесь и ниже
            lstbox.Height = 150;
            lstbox.SelectionChanged += ListBoxOnSelectionChanged;
            Content = lstbox; // Заполнить ListBox цветами           
            PropertyInfo[] props = typeof(Colors) .GetProperties();
            foreach (PropertyInfo prop in props)
                lstbox.Items.Add(prop.Name);
        }
        void ListBoxOnSelectionChanged(object sender, SelectionChangedEventArgs args) {
            ListBox lstbox = sender as ListBox;
            string str = lstbox.SelectedItem as  string;
            if (str != null) {
                Color clr = (Color)typeof(Colors) .GetProperty(str).GetValue(null, null);
                Background = new SolidColorBrush(clr);
            }
        }
    }
}