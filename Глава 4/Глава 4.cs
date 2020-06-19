using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
namespace Petzold.CommandTheButton {
    public class CommandTheButton : Window { [STAThread]
        public static void Main() {
            Application app = new Application(); // Инициализация объекта
            app.Run(new CommandTheButton());
        }
        public CommandTheButton(){ 
            Title = "Command the Button"; // Заголовок           
            Button btn = new Button(); // Инициализация кнопки
            btn.HorizontalAlignment =  HorizontalAlignment.Center; // Центрирование
            btn.VerticalAlignment =  VerticalAlignment.Center;
            btn.Command = ApplicationCommands.Paste;
            btn.Content = ApplicationCommands .Paste.Text;
            Content = btn;             // Ссвязывание команд с обработчиками событий      
            CommandBindings.Add(new CommandBinding (ApplicationCommands.Paste, PasteOnExecute, PasteCanExecute)); 
        }
        void PasteOnExecute(object sender,  ExecutedRoutedEventArgs args)
        {Title = Clipboard.GetText(); // Отправление данных в буфер обмена
        }
        void PasteCanExecute(object sender,  CanExecuteRoutedEventArgs args)
        {args.CanExecute = Clipboard .ContainsText();
        }
        protected override void OnMouseDown (MouseButtonEventArgs args) // Предоставление данных для мыши
        {base.OnMouseDown(args);
            Title = "Command the Button";
        }
    }
} 